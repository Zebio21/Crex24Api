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
        public CrexCoinBalance[] Balances(string[] coins = null, bool? nonZeroOnly = null);

        // TODO: 
    }
}
