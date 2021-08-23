using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Crypto Withdrawal Preview
    /// Returns an object with the following structure
    /// </summary>
    public class CrexWithdrawalPreview
    {
        /// <summary>
        /// If withdrawal meets formal requirements (minimum and maximum limits, withdrawal amount covers the fee, etc.),
        /// the field contains the value null, and the fields below provide a preview information for a withdrawal with the specified parameters.
        /// </summary>
        [JsonProperty("warning")]
        public string Warning { get; set; }

        /// <summary>
        /// The total amount that will be debited from the account (subtracted from the balance), if the withdrawal is performed
        /// </summary>
        [JsonProperty("balanceDeduction")]
        public decimal BalanceDeduction { get; set; }

        /// <summary>
        /// The size of the fee that will be charged, if the withdrawal is performed
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// The amount that will be transferred to the specified address, if the withdrawal is performed
        /// </summary>
        [JsonProperty("payout")]
        public decimal Payout { get; set; }
    }
}
