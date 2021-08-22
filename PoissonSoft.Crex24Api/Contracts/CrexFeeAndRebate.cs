using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public class CrexFeeAndRebate
    {
        /// <summary>
        /// An array of objects, one per fee schedule, each describing currently applied fee rate
        /// </summary>
        [JsonProperty("feeRates")]
        public FeeRate[] FeeRates { get; set; }

        /// <summary>
        /// Total volume of trades that took place over the last 30 days, expressed in BTC
        /// </summary>
        [JsonProperty("tradingVolume")]
        public decimal TradingVolume { get; set; }

        /// <summary>
        /// Date and time when the fee rates and 30-day trading volume were last updated
        /// </summary>
        [JsonProperty("lastUpdate")]
        public DateTime LastUpdate { get; set; }
    }

    /// <summary>
    /// Structure of FeeRate object
    /// </summary>
    public class FeeRate
    {
        /// <summary>
        /// Name of the fee schedule
        /// </summary>
        [JsonProperty("schedule")]
        public string Schedule { get; set; }

        /// <summary>
        /// Currently applied maker-fee rate of the schedule.
        /// </summary>
        [JsonProperty("maker")]
        public decimal Maker { get; set; }

        /// <summary>
        /// Currently applied taker-fee rate of the schedule.
        /// </summary>
        [JsonProperty("taker")]
        public decimal Taker { get; set; }
    }
}
