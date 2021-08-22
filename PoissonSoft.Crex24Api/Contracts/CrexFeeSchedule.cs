using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// List of all trading fee schedules with detailed information
    /// </summary>
    public class CrexFeeSchedule
    {
        /// <summary>
        /// Unique name of the fee schedule
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An array of objects each representing a fee tier
        /// (maker and taker fee rates that come in force once a corresponding trading volume threshold has been met),
        /// ordered by volumeThreshold from smallest to largest
        /// </summary>
        [JsonProperty("feeRates")]
        public FeeTier[] FeeRates { get; set; }
    }

    public class FeeTier
    {
        /// <summary>
        /// The value of 30-day trading volume (expressed in BTC) that must be reached to qualify for the tier
        /// </summary>
        [JsonProperty("volumeThreshold")]
        public decimal VolumeThreshold { get; set; }

        /// <summary>
        /// Market-maker fee rate
        /// </summary>
        [JsonProperty("maker")]
        public decimal Maker { get; set; }

        /// <summary>
        /// Market-taker fee rate
        /// </summary>
        [JsonProperty("taker")]
        public decimal Taker { get; set; }
    }
}
