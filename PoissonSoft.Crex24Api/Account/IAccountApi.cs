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
        CrexCoinBalance[] Balances(string coins = null, bool? nonZeroOnly = null);

        /// <summary>
        /// Returns the address (and Payment ID, if necessary) for cryptocurrency deposit.
        /// </summary>
        /// <param name="coin">Identifier of the cryptocurrency, that you would like to deposit</param>
        /// <param name="transports">Optional. Identifier of the transport, that you would use to deposit.</param>
        /// <returns></returns>
        CrexDepositAddress DepositAddress(string coin, string transports = null);

        /// <summary>
        /// Returns information about deposits and withdrawals.
        /// </summary>
        /// <param name="transferType">Optional. Filters money transfers by type, can have either of the two values:
        /// "deposit" - get deposits only;
        /// "withdrawal" - get withdrawals only.</param>
        /// <param name="coins">Optional. Comma-separated list of currencies for which the money transfer history is requested. If the parameter is not specified,
        /// the money transfers are returned for all currencies</param>
        /// <param name="from">Optional. The start point of the time frame from which the money transfer history is collected</param>
        /// <param name="till">Optional. The end point of the time frame from which the money transfer history is collected</param>
        /// <param name="limit">Optional. Maximum number of results per call. Accepted values: 1 - 1000. If the parameter is not specified,
        /// the number of results is limited to 100</param>
        /// <returns></returns>
        CrexTransferHistory[] MoneyTransferHistory(string transferType = null, string[] coins = null,
            DateTime? from = null, DateTime? till = null, ushort? limit = null);

        /// <summary>
        /// Returns information about the specified money transfer(s).
        /// </summary>
        /// <param name="transferType">Comma-separated list of identifiers of money transfers for which the detailed information is requested</param>
        /// <returns></returns>
        CrexTransferHistory[] MoneyTransferStatus(long[] transferType);

        /// <summary>
        /// Allows previewing a cryptocurrency withdrawal without actually conducting it.
        /// Useful for estimating the size of non-flat withdrawal fee and ensuring that the withdrawal meets formal requirements.
        /// </summary>
        /// <param name="currency">The value of parameter currency that will be specified in the actual withdrawal request</param>
        /// <param name="amount">The value of parameter amount that will be specified in the actual withdrawal request</param>
        /// <param name="feeCurrency">The value of parameter feeCurrency that will be specified in the actual withdrawal request</param>
        /// <param name="includeFee">Optional. The value of parameter includeFee that will be specified in the actual withdrawal request</param>
        /// <param name="transport">Optional. The value of parameter transport that will be specified in the actual withdrawal request</param>
        /// <returns></returns>
        CrexWithdrawalPreview WithdrawalPreview(string currency, decimal amount,
            string feeCurrency, bool? includeFee = null, string transport = null);

        /// <summary>
        /// Withdraws certain amount of cryptocurrency from the account and sends it to the specified crypto address.
        /// </summary>
        /// <param name="currency">Currency identifier</param>
        /// <param name="amount">Withdrawal amount (the precision is limited to a number of decimal places specified in the withdrawalPrecision field of the Currency,
        /// the value is rounded automatically to meet the precision limitation)</param>
        /// <param name="address">Crypto address to which the money will be transferred</param>
        /// <param name="feeCurrency">Optional. Additional information (such as Payment ID, Message, Memo, etc.)
        /// that specifies the destination of money transfer along with the address. </param>
        /// <param name="paymentId">Currency identifier to be used to pay the commission</param>
        /// <param name="includeFee">Optional. Sets whether the specified amount includes fee, can have either of the two values:
        /// true - balance will be decreased by amount, whereas [amount - fee] will be transferred to the specified address;
        /// false - amount will be deposited to the specified address, whereas the balance will be decreased by [amount + fee].
        /// The default value is false</param>
        /// <param name="transport">Optional. Transport identifier</param>
        /// <returns></returns>
        CrexTransferHistory Withdrawal(string currency, decimal amount,
            string address, string feeCurrency, string paymentId = null, bool? includeFee = null,
            string transport = null);



        // TODO: 
    }
}
