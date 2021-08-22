using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Array of CurrencyFees objects, each with the following structure
    /// </summary>
    public class CrexCurrenciesWithdrawlFees
    {
        /// <summary>
        /// Currency identifier
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// An array of objects each representing a possible currency and amount for withdrawal fee payout
        /// </summary>
        [JsonProperty("fees")]
        public CrexFeeCurrency[] Fees { get; set; }
    }
}
