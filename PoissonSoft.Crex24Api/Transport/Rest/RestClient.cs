using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using NLog;
using PoissonSoft.Crex24Api.Contracts.Exceptions;
using PoissonSoft.Crex24Api.Contracts.Requests;
using PoissonSoft.Crex24Api.Contracts.Serialization;
using PoissonSoft.Crex24Api.Utils;

namespace PoissonSoft.Crex24Api.Transport.Rest
{
    internal class RestClient : IDisposable
    {
        private readonly ILogger logger;
        private readonly Throttler throttler;
        private readonly string userFriendlyName;

        private readonly HttpClient httpClient;
        private readonly bool useSignature;
        private readonly byte[] secretKey;

        private readonly JsonSerializerSettings serializerSettings;

        public RestClient(ILogger logger, string baseEndpoint, Throttler throttler, Crex24ApiClientCredentials credentials)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.throttler = throttler ?? throw new ArgumentNullException(nameof(throttler));

            string apiKey = string.Empty;
            if (!string.IsNullOrWhiteSpace(credentials?.ApiKey) && !string.IsNullOrWhiteSpace(credentials.SecretKey))
            {
                useSignature = true;
                apiKey = credentials.ApiKey;
                secretKey = Convert.FromBase64String(credentials.SecretKey);
            }

            userFriendlyName = $"{nameof(RestClient)} ({baseEndpoint})";

            serializerSettings = new JsonSerializerSettings
            {
                Context = new StreamingContext(StreamingContextStates.All,
                    new SerializationContext { Logger = logger })
            };

            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
                Proxy = ProxyHelper.CreateProxy(credentials)
            };

            baseEndpoint = baseEndpoint.Trim();
            if (!baseEndpoint.EndsWith("/")) baseEndpoint += '/';
            httpClient = new HttpClient(httpClientHandler, true)
            {
                Timeout = TimeSpan.FromSeconds(20),
                BaseAddress = new Uri(baseEndpoint),
            };
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (useSignature)
            {
                httpClient.DefaultRequestHeaders.Add("X-CREX24-API-KEY", apiKey);
            }
        }


        /// <summary>
        /// Выполнить запрос
        /// </summary>
        /// <typeparam name="TRec">Тип отправляемых в запросе данных</typeparam>
        /// <typeparam name="TResp">Тип возвращаемого значения</typeparam>
        /// <param name="httpMethod">Метод запроса GET/POST</param>
        /// <param name="urlPath">Путь к ресурсу (без базового адреса эндпоинта)</param>
        /// <param name="reqParams">Данные запроса</param>
        /// <param name="highPriority">Признак запроса с высоким приоритетом</param>
        /// <returns></returns>
        public TResp MakeRequest<TRec, TResp>(HttpMethod httpMethod, string urlPath, TRec reqParams, bool highPriority = false) where TRec : class
        {
            if (httpMethod != HttpMethod.Get && httpMethod != HttpMethod.Post)
                throw new Exception($"Unsupported HTTP-method {httpMethod}");

            throttler.ThrottleRest(highPriority);

            void checkResponse(HttpResponseMessage resp, string body)
            {
                if (resp.StatusCode == HttpStatusCode.OK) return;

                string msg;

                // HTTP 429 The request rate quota is exceeded. Cut down the number of requests per second or contact the
                // support to have your personal request rate limit raised.
                if (resp.StatusCode == (HttpStatusCode)429)
                {
                    throttler.StopAllRequestsDueToRateLimit();

                    msg = $"{userFriendlyName}. Обнаружено превышение лимита запросов. " +
                          $"{(int)resp.StatusCode} ({resp.ReasonPhrase}).";
                    logger.Error(msg);
                    throw new RequestRateLimitBreakingException(msg);
                }

                msg = $"{userFriendlyName}. На запрос {urlPath} от сервера получен код ответа" +
                      $" {(int)resp.StatusCode} ({resp.StatusCode})\nТело ответа:\n{body}";
                logger.Error(msg);
                throw new EndpointCommunicationException(msg);
            }


            var url = urlPath;
            if (httpMethod == HttpMethod.Get && reqParams != null) url += ConvertingHelper.ToGetParams(reqParams);

            string body = null;
            if (httpMethod == HttpMethod.Post && reqParams != null)
            {
                body = JsonConvert.SerializeObject(reqParams);
            }

            string strResp;
            try
            {
                using var content = body != null ? new StringContent(body, Encoding.UTF8, "application/json") : null;
                using var request = new HttpRequestMessage(httpMethod, url)
                {
                    Content = content
                };
                if (useSignature)
                {
                    SignRequest(request, body);
                }
                using var result = httpClient.SendAsync(request).Result;
                strResp = result.Content.ReadAsStringAsync().Result;
                checkResponse(result, strResp);
            }
            catch (EndpointCommunicationException)
            {
                throw;
            }
            catch (HttpRequestException e)
            {
                logger.Error($"{userFriendlyName}. При отправке HTTP-запроса возникло исключение\n{e}");
                throw;
            }
            catch (AggregateException e) when (e.InnerExceptions.Count == 1 &&
                                               e.InnerExceptions[0] is TaskCanceledException)
            {
                var msg = $"{userFriendlyName}. Возникло исключение {nameof(TaskCanceledException)} в связи с истечением таймаута запроса. " +
                          "Возможно, сервер временно не доступен";
                logger.Error(msg);
                throw new TimeoutException(msg, e);
            }
            catch (Exception e)
            {
                logger.Error($"{userFriendlyName}. При запросе данных с сервера возникло исключение\n{e}");
                throw;
            }

            if (string.IsNullOrWhiteSpace(strResp)) return default;
            if (typeof(TResp) == typeof(string)) return (TResp)(object)strResp;

            try
            {
                return JsonConvert.DeserializeObject<TResp>(strResp, serializerSettings);
            }
            catch (Exception e)
            {
                logger.Error($"{userFriendlyName}. Попытка десериализации строки, полученной от сервера вызвала исключение\n" +
                             $"Ответ сервера: {strResp}\n{e}");
                throw;
            }
        }
        
        private void SignRequest(HttpRequestMessage request, string body)
        {
            var nonce = GetNonce();
            request.Headers.Add("X-CREX24-API-NONCE", nonce.ToString());
            var msg = Encoding.UTF8.GetBytes($"{httpClient.BaseAddress.PathAndQuery}{request.RequestUri}{nonce}{body ?? string.Empty}");
            request.Headers.Add("X-CREX24-API-SIGN", Convert.ToBase64String(new HMACSHA512(secretKey).ComputeHash(msg)));
        }

        private static DateTimeOffset nextAdjustNonce = DateTimeOffset.UtcNow.AddMinutes(5);
        private static long lastNonce = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        private static readonly object syncNonce = new object();
        private static long GetNonce()
        {
            if (DateTimeOffset.UtcNow > nextAdjustNonce)
            {
                lock (syncNonce)
                {
                    if (DateTimeOffset.UtcNow > nextAdjustNonce)
                    {
                        var ts = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                        if (ts > lastNonce) lastNonce = ts;
                        nextAdjustNonce = DateTimeOffset.UtcNow.AddMinutes(5);
                    }
                }
            }

            return Interlocked.Increment(ref lastNonce);
        }


        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}
