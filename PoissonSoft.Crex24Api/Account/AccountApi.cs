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
        public void Dispose()
        {
            client?.Dispose();
        }

        /// <inheritdoc />
        public CrexCoinBalance[] Balances(string[] coins = null, bool? nonZeroOnly = null)
        {
            return client.MakeRequest<ReqBalances, CrexCoinBalance[]>(HttpMethod.Get, "balance", new ReqBalances
            {
                CoinFilter = coins,
                NonZeroBalancesOnly = nonZeroOnly
            });
        }
    }
}
