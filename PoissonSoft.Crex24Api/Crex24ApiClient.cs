using System;
using NLog;
using PoissonSoft.Crex24Api.MarketData;

namespace PoissonSoft.Crex24Api
{
    /// <summary>
    /// Client to work with Crex24 BotAPI
    /// </summary>
    public sealed class Crex24ApiClient
    {

        private readonly Crex24ApiClientCredentials credentials;

        internal ILogger Logger { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="credentials"></param>
        /// <param name="logger"></param>
        public Crex24ApiClient(Crex24ApiClientCredentials credentials, ILogger logger)
        {
            this.credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));

            marketDataApi = new MarketDataApi();
        }

        /// <summary>
        /// MarketData Rest-API
        /// </summary>
        public IMarketDataApi MarketDataApi => marketDataApi;
        private readonly MarketDataApi marketDataApi;
    }
}
