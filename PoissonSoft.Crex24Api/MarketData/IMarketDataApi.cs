using System;
using System.Collections.Generic;
using System.Text;
using PoissonSoft.Crex24Api.Contracts;

namespace PoissonSoft.Crex24Api.MarketData
{
    /// <summary>
    /// Market Data API
    /// </summary>
    public interface IMarketDataApi
    {
        /// <summary>
        /// Returns the list of available currencies (including coins, tokens, etc.) with detailed information.
        /// </summary>
        /// <param name="coins">Optional. Comma-separated list of currencies for which the detailed information is requested.
        /// If the parameter is not specified, the detailed information about all available currencies is returned</param>
        /// <returns></returns>
        CrexCoin[] Currencies(string[] coins = null);

        /// <summary>
        /// Returns the list of available trade instruments with detailed information.
        /// </summary>
        /// <param name="instruments"> Optional. Comma-separated list of instruments for which the detailed information is requested.
        /// If the parameter is not specified, the detailed information about all available instruments is returned</param>
        /// <returns></returns>
        CrexInstrument[] Instruments(string[] instruments = null);

        /// <summary>
        /// Returns the list of tickers with detailed information.
        /// </summary>
        /// <param name="instruments"> Optional. Comma-separated list of instruments for which the detailed information is requested.
        /// If the parameter is not specified, the detailed information about all available instruments is returned</param>
        /// <returns></returns>
        /// <returns></returns>
        CrexQuote[] Tickers(string[] instruments = null);

        /// <summary>
        /// Returns information about bids and asks for the specified instrument, organized by price level.
        /// </summary>
        /// <param name="instrument">Trade instrument for which the order book is requested</param>
        /// <param name="limit">Optional. Maximum number of returned price levels (both buying and selling) per call.
        /// If the parameter is not specified, the number of levels is limited to 100</param>
        /// <returns></returns>
        CrexOrderBook OrderBook(string instrument, int? limit = null);

        /// <summary>
        /// Returns the list of all fees for currencies withdrawal.
        /// </summary>
        /// <param name="coins">Optional. Comma-separated list of currencies for which the withdrawal fees is requested.
        /// If the parameter is not specified, the withdrawal fees about all available currencies is returned</param>
        /// <returns></returns>
        CrexFeeCurrency[] WithdrawalFees(string[] coins = null);

        /// <summary>
        /// Returns detailed information about transport blockchain for cryptocurrency.
        /// </summary>
        /// <param name="coin">Currency identifier</param>
        /// <param name="transport">Transport identifier (all available transports for currency are specified
        /// in the transports field of the Currency)</param>
        /// <returns></returns>
        CrexBlockchainTransport[] CurrencyTransport(string coin, string transport);
    }
}
