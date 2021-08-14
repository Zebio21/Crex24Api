using System;
using NLog;
using PoissonSoft.Crex24Api.Account;
using PoissonSoft.Crex24Api.MarketData;
using PoissonSoft.Crex24Api.Trading;
using PoissonSoft.Crex24Api.Transport;

namespace PoissonSoft.Crex24Api
{
    /// <summary>
    /// Client to work with Crex24 BotAPI
    /// </summary>
    public sealed class Crex24ApiClient: IDisposable
    {
        private readonly Crex24ApiClientCredentials credentials;
        private readonly ILogger logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="logger"></param>
        public Crex24ApiClient(Crex24ApiClientCredentials credentials, ILogger logger)
        {
            this.credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            var throttler = new Throttler(logger);

            marketDataApi = new MarketDataApi(throttler, logger);
            tradingApi = new TradingApi(throttler, logger, credentials);
            accountApi = new AccountApi(throttler, logger, credentials);
        }

        /// <summary>
        /// MarketData Rest-API
        /// </summary>
        public IMarketDataApi MarketDataApi => marketDataApi;
        private readonly MarketDataApi marketDataApi;

        /// <summary>
        /// Trading Rest-API
        /// </summary>
        public ITradingApi TradingApi => tradingApi;
        private readonly TradingApi tradingApi;

        /// <summary>
        /// Trading Rest-API
        /// </summary>
        public IAccountApi AccountApi => accountApi;
        private readonly AccountApi accountApi;

        /// <inheritdoc />
        public void Dispose()
        {
            marketDataApi?.Dispose();
            tradingApi?.Dispose();
            accountApi?.Dispose();
        }
    }
}
