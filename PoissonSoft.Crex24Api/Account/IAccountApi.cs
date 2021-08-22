using System;
using System.Collections.Generic;
using System.Text;
using PoissonSoft.Crex24Api.Contracts;

namespace PoissonSoft.Crex24Api.Account
{
    /// <summary>
    /// Account API
    /// </summary>
    public interface IAccountApi
    {
        /// <summary>
        /// Returns information about trader’s balances in different currencies.
        /// </summary>
        /// <param name="coins">Optional. Comma-separated list of currencies for which the balance information is requested.
        /// If the parameter is not specified, the balance information is requested for all currencies</param>
        /// <param name="nonZeroOnly">Optional. Can have either of the two values: true - return only non-zero balances;
        /// false - return all balances. The default value is true</param>
        /// <returns></returns>
        CrexCoinBalance[] Balances(string[] coins = null, bool? nonZeroOnly = null);

        /// <summary>
        /// Returns the address (and Payment ID, if necessary) for cryptocurrency deposit.
        /// </summary>
        /// <param name="coin">Identifier of the cryptocurrency, that you would like to deposit</param>
        /// <param name="transports">Optional. Identifier of the transport, that you would use to deposit.</param>
        /// <returns></returns>
        CrexDepositAddress CryptoDepositAddress(string coin, string transports = null);

        /// <summary>
        /// Returns information about deposits and withdrawals.
        /// </summary>
        /// <param name="transferType"></param>
        /// <param name="coins"></param>
        /// <param name="from"></param>
        /// <param name="till"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        CrexTransferHistory[] MoneyTransferHistory(string transferType, string[] coins = null,
            DateTime? from = null, DateTime? till = null, ushort? limit = null);

        // TODO: 
    }
}
