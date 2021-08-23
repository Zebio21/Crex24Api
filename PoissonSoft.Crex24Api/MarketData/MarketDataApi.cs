using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using NLog;
using PoissonSoft.Crex24Api.Contracts;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Requests;
using PoissonSoft.Crex24Api.Transport;
using PoissonSoft.Crex24Api.Transport.Rest;
using PoissonSoft.Crex24Api.Utils;

namespace PoissonSoft.Crex24Api.MarketData
{
    /// <summary>
    /// Market Data API
    /// </summary>
    public sealed class MarketDataApi: IMarketDataApi, IDisposable
    {

        private readonly RestClient client;

        internal MarketDataApi(Throttler throttler, ILogger logger)
        {
            client = new RestClient(logger, "https://api.crex24.com/v2/public", throttler, null);
        }

        /// <inheritdoc />
        public CrexCoin[] Currencies(string[] coins = null)
        {
            return client.MakeRequest<ReqFilter, CrexCoin[]>(HttpMethod.Get, "currencies",
                new ReqFilter { FilterItems = coins });
        }

        /// <inheritdoc />
        public CrexInstrument[] Instruments(string[] instruments = null)
        {
            return client.MakeRequest<ReqFilter, CrexInstrument[]>(HttpMethod.Get, "instruments",
                new ReqFilter { FilterItems = instruments?.Select(x => x.Replace('/','-')).ToArray() });
        }

        /// <inheritdoc />
        public CrexQuote[] Tickers(string[] instruments = null)
        {
            return client.MakeRequest<ReqInstrumentFilter, CrexQuote[]>(HttpMethod.Get, "tickers",
                new ReqInstrumentFilter
                {
                    InstrumentTickers = instruments?.Select(ConvertingHelper.InstrumentHumanToApi).ToArray()
                });
        }

        /// <inheritdoc />
        public CrexRecentTrade[] RecentTrades(string instrument, int? limit = null)
        {
            return client.MakeRequest<ReqOrderBook, CrexRecentTrade[]>(HttpMethod.Get, "recentTrades", new ReqOrderBook
            {
                InstrumentTicker = instrument.InstrumentHumanToApi(),
                Limit = limit
            });
        }
        
        /// <inheritdoc />
        public CrexOrderBook OrderBook(string instrument, int? limit = null)
        {
            return client.MakeRequest<ReqOrderBook, CrexOrderBook>(HttpMethod.Get, "orderBook", new ReqOrderBook
            {
                InstrumentTicker = instrument.InstrumentHumanToApi(),
                Limit = limit
            });
        }

        /// <inheritdoc />
        public CrexOHLCVData[] OHLCVData(string instrument, Granularity granularityVal, int? limit = null)
        {
            return client.MakeRequest<ReqOHLCVData, CrexOHLCVData[]>(HttpMethod.Get, "ohlcv", new ReqOHLCVData
            {
                InstrumentTicker = instrument.InstrumentHumanToApi(),
                Granularity = granularityVal,
                Limit = limit
            });
        }

        /// <inheritdoc />
        public CrexFeeSchedule[] TradingFeeSchedules()
        {
            return client.MakeRequest<ReqFilter, CrexFeeSchedule[]>(HttpMethod.Get, "tradingFeeSchedules", null);
        }

        /// <inheritdoc />
        public CrexFeeCurrency[] WithdrawalFees(string coin)
        {
            return client.MakeRequest<ReqWithdrawalFees, CrexFeeCurrency[]>(HttpMethod.Get, "withdrawalFees", new ReqWithdrawalFees
            {
                WithdrawingCoinTicker = coin
            });
        }

        /// <inheritdoc />
        public CrexCurrenciesWithdrawlFees[] CurrenciesWithdrawalFees(string[] coins = null)
        {
            return client.MakeRequest<ReqFilter, CrexCurrenciesWithdrawlFees[]>(HttpMethod.Get, "currenciesWithdrawalFees", new ReqFilter
            {
                FilterItems = coins
            });
        }

        /// <inheritdoc />
        public CrexBlockchainTransport CurrencyTransport(string coin, string transport)
        {
            return client.MakeRequest<ReqDepositAddress, CrexBlockchainTransport>(HttpMethod.Get, "currencyTransport", 
                new ReqDepositAddress
                {
                    CoinTicker = coin,
                    Transport = transport
                });
        }

        /// <inheritdoc />
        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
