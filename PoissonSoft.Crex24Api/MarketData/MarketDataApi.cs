using System;
using System.Collections.Generic;
using System.Text;
using PoissonSoft.Crex24Api.Contracts;

namespace PoissonSoft.Crex24Api.MarketData
{
    /// <inheritdoc />
    public sealed class MarketDataApi: IMarketDataApi
    {
        /// <inheritdoc />
        public CrexCoin[] Currencies(string[] coins = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public CrexInstrument[] Instruments(string[] instruments = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public CrexQuote[] Tickers(string[] instruments = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public CrexOrderBook OrderBook(string instrument, int? limit = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public CrexFeeCurrency[] WithdrawalFees(string[] coins = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public CrexBlockchainTransport[] CurrencyTransport(string coin, string transport)
        {
            throw new NotImplementedException();
        }
    }
}
