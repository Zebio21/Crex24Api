using System;
using System.Threading;
using NLog;
using PoissonSoft.Crex24Api.Contracts.Exceptions;
using PoissonSoft.Crex24Api.Utils;

namespace PoissonSoft.Crex24Api.Transport
{
    internal class Throttler: IDisposable
    {
        private readonly ILogger logger;

        private readonly string userFriendlyName = nameof(Throttler);
        private readonly WaitablePool syncPool;
        
        // "Стоимость" одного запроса в миллисекундах для каждого из параллельно исполняемых REST-запросов.
        // Т.е. если в конкретном потоке (одном из всех MaxDegreeOfParallelism параллельных) выполняется запрос
        // то этот поток не должен проводить новых запросов в течение requestWeightCostInMs миллисекунд
        private int requestCostInMs;

        // Значение по умолчанию для времени приостановки запросов после превышения лимита (в секундах)
        private int defaultRetryAfterSec = 60;

        // Время (UTC), до которого приостановлены все запросы в связи с превышением лимита
        private object rateLimitPausedTime = DateTimeOffset.MinValue;

        /// <summary>
        /// Максимальное количество параллельно выполняемых запросов
        /// </summary>
        public int MaxDegreeOfParallelism { get; }

        /// <summary>
        /// Количество Feeds, выделяемых под высоко-приоритетные запросы
        /// Значение должно быть строго меньше чем <see cref="MaxDegreeOfParallelism"/>
        /// </summary>
        public int HighPriorityFeedsCount { get; }

        /// <summary>
        /// Create instance
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="rateLimit">Контролируемый RateLimit. Если не задано, будет использован RateLimit по умолчанию</param>
        /// <param name="maxDegreeOfParallelism">Максимальное допустимое количество параллельно выполняемых запросов</param>
        /// <param name="highPriorityFeedsCount">Количество feeds, выделяемое под исполнение запросов с высоким приоритетом</param>
        public Throttler(ILogger logger, RateLimit rateLimit = null, int maxDegreeOfParallelism = 5, int highPriorityFeedsCount = 1)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            MaxDegreeOfParallelism = maxDegreeOfParallelism;
            if (MaxDegreeOfParallelism < 1) MaxDegreeOfParallelism = 1;

            HighPriorityFeedsCount = highPriorityFeedsCount;
            if (HighPriorityFeedsCount >= MaxDegreeOfParallelism)
                HighPriorityFeedsCount = MaxDegreeOfParallelism - 1;


            ApplyLimit(rateLimit ?? RateLimit.Default);

            syncPool = new WaitablePool(MaxDegreeOfParallelism, highPriorityFeedsCount);

        }

        /// <summary>
        /// Применить актуальные лимиты
        /// </summary>
        /// <param name="limit"></param>
        public void ApplyLimit(RateLimit limit)
        {
            double requestsPerSecondLimit = limit.Limit / limit.Interval.TotalSeconds;
            var costMs = (int)Math.Ceiling(1000 / requestsPerSecondLimit) * MaxDegreeOfParallelism;
            Interlocked.Exchange(ref requestCostInMs, costMs);
        }

        /// <summary>
        /// REST-request throttling
        /// </summary>
        /// <param name="highPriority"></param>
        public void ThrottleRest(bool highPriority)
        {
            var dt = DateTimeOffset.UtcNow;
            var locker = syncPool.Wait(highPriority);
            locker.UnlockAfterMs(requestCostInMs);
            var waitTime = (DateTimeOffset.UtcNow - dt).TotalSeconds;
            if (waitTime > 5)
            {
                logger.Warn($"{userFriendlyName}. Время ожидания тротлинга REST-запроса составило {waitTime:F0} секунд. " +
                                      "Возможно, следует оптимизировать прикладные алгоритмы с целью сокращения количества запросов");
            }

            // Здесь не используем Interlocked для чтения rateLimitPausedTime по следующим соображениям:
            // - кривое значение будет прочитано в исключительно редких случаях, при этом возможно будет пропущен запрос, который следовало пресечь, или
            //   остановлен запрос, который следовало пропустить. Это не является большой проблемой
            // - в подавляющем большинстве случаев запрос будет пропускаться, при этом лишняя задержка на Interlocked операцию здесь выглядит совсем лишней
            if (DateTimeOffset.UtcNow < (DateTimeOffset)rateLimitPausedTime)
                throw new RequestRateLimitBreakingException($"All requests banned until {(DateTimeOffset)rateLimitPausedTime}");
        }

        /// <summary>
        /// HTTP 429 The request rate quota is exceeded. Cut down the number of requests per second or contact the support
        /// to have your personal request rate limit raised
        /// </summary>
        /// <param name="retryAfter">Время приостановки приёма запросов</param>
        public void StopAllRequestsDueToRateLimit(TimeSpan? retryAfter = null)
        {
            var timeout = retryAfter ?? TimeSpan.FromSeconds(defaultRetryAfterSec);

            var pausedTime = DateTimeOffset.UtcNow + timeout;

            Interlocked.Exchange(ref rateLimitPausedTime, pausedTime);
        }

        public void Dispose()
        {
            syncPool?.Dispose();
        }
    }
}
