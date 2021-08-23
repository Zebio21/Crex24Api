using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using NLog;
using PoissonSoft.Crex24Api.Contracts;
using PoissonSoft.Crex24Api.Contracts.Requests;
using PoissonSoft.Crex24Api.Transport;
using PoissonSoft.Crex24Api.Transport.Rest;

namespace PoissonSoft.Crex24Api.Account
{
    /// <summary>
    /// Account API
    /// </summary>
    public sealed class AccountApi: IAccountApi, IDisposable
    {
        private readonly RestClient client;

        internal AccountApi(Throttler throttler, ILogger logger, Crex24ApiClientCredentials credentials)
        {
            client = new RestClient(logger, "https://api.crex24.com/v2/account", throttler, credentials);
        }

        // TODO:
        
        /// <inheritdoc />
        public CrexCoinBalance[] Balances(string coins = null, bool? nonZeroOnly = null)
        {
            return client.MakeRequest<ReqBalances, CrexCoinBalance[]>(HttpMethod.Get, "balance", new ReqBalances
            {
                CoinFilter = coins,
                NonZeroBalancesOnly = nonZeroOnly
            });
        }

        /// <inheritdoc />
        public CrexDepositAddress DepositAddress(string coin, string transports = null)
        {
            return client.MakeRequest<ReqDepositAddress, CrexDepositAddress>(HttpMethod.Get, "depositAddress", new ReqDepositAddress
            {
                CoinTicker = coin,
                Transport = transports
            });
        }

        /// <inheritdoc />
        public CrexTransferHistory[] MoneyTransferHistory(string transferType, string[] coins = null, 
                                                        DateTime? from = null, DateTime? till = null, ushort? limit = null)
        {
            return client.MakeRequest<ReqMoneyTransfers, CrexTransferHistory[]>(HttpMethod.Get, "moneyTransfers", new ReqMoneyTransfers
            {
                TransferType = transferType,
                CoinTickers = coins,
                From = from,
                Till = till,
                Limit = limit
            });
        }

        /// <inheritdoc />
        public CrexTransferHistory[] MoneyTransferStatus(ulong transferId) //TODO
        {
            return client.MakeRequest<ReqOrderTrades, CrexTransferHistory[]>(HttpMethod.Get, "moneyTransferStatus", new ReqOrderTrades
            {
                OrderId = transferId,
            });
        }

        /// <inheritdoc />
        public CrexWithdrawalPreview WithdrawalPreview(string currency, decimal amount,
            string feeCurrency, bool? includeFee = null, string transport = null)
        {
            return client.MakeRequest<ReqWithdrawalPreview, CrexWithdrawalPreview>(HttpMethod.Get, "previewWithdrawal", new ReqWithdrawalPreview
            {
                CoinTicker = currency,
                Amount = amount,
                FeeCurrency = feeCurrency,
                IncludeFee = includeFee,
                Transport = transport
            });
        }

        /// <inheritdoc />
        public CrexTransferHistory Withdrawal(string currency, decimal amount,
            string address, string feeCurrency, string paymentId = null, bool? includeFee = null, string transport = null)
        {
            return client.MakeRequest<ReqWithdrawal, CrexTransferHistory>(HttpMethod.Post, "withdraw", new ReqWithdrawal
            {
                CoinTicker = currency,
                Amount = amount,
                Address = address,
                FeeCurrency = feeCurrency,
                PaymentId = paymentId,
                IncludeFee = includeFee,
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
