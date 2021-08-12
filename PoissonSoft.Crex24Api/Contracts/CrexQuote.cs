using System;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Crex "Ticker" object
    /// </summary>
    public class CrexQuote
    {
        /// <summary>
        /// Unique ticker identifier, e.g. "LTC-BTC"
        /// </summary>
        [JsonProperty("instrument")]
        public string InstrumentTicker { get; set; }

        /// <summary>
        /// Last price. If this information is not available, the field contains the value null
        /// </summary>
        [JsonProperty("last")]
        public decimal? LastPrice { get; set; }

        /// <summary>
        /// Percentage change of the price over the last 24 hours. If this information is not available, the field contains the value null
        /// </summary>
        [JsonProperty("percentChange")]
        public decimal? PercentChange { get; set; }

        /// <summary>
        /// Lowest price over the last 24 hours. If this information is not available, the field contains the value null
        /// </summary>
        [JsonProperty("low")]
        public decimal? LowPrice { get; set; }

        /// <summary>
        /// Highest price over the last 24 hours. If this information is not available, the field contains the value null
        /// </summary>
        [JsonProperty("high")]
        public decimal? HighPrice { get; set; }

        /// <summary>
        /// Total trading volume of the instrument over the last 24 hours, expressed in base currency
        /// </summary>
        [JsonProperty("baseVolume")]
        public decimal VolumeBase { get; set; }

        /// <summary>
        /// Total trading volume of the instrument over the last 24 hours, expressed in quote currency
        /// </summary>
        [JsonProperty("quoteVolume")]
        public decimal VolumeQuote { get; set; }

        /// <summary>
        /// Total trading volume of the instrument over the last 24 hours, expressed in BTC
        /// </summary>
        [JsonProperty("volumeInBtc")]
        public decimal VolumeBtc { get; set; }

        /// <summary>
        /// Total trading volume of the instrument over the last 24 hours, expressed in USD
        /// </summary>
        [JsonProperty("volumeInUsd")]
        public decimal VolumeUsd { get; set; }

        /// <summary>
        /// Best ask price.
        /// If there are no active selling orders, the field contains the value null
        /// </summary>
        [JsonProperty("ask")]
        public decimal? Ask { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("bid")]
        public decimal? Bid { get; set; }

        /// <summary>
        /// Best bid price.
        /// If there are no active buying orders at the moment, the field contains the value null
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
