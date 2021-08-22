using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    public class CrexOHLCVData
    {
        /// <summary>
        /// Date and time when the timeframe started
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Opening price
        /// </summary>
        [JsonProperty("open")]
        public decimal OpenPrice { get; set; }

        /// <summary>
        /// Highest price
        /// </summary>
        [JsonProperty("high")]
        public decimal HighPrice { get; set; }

        /// <summary>
        /// Lowest price
        /// </summary>
        [JsonProperty("low")]
        public decimal LowPrice { get; set; }

        /// <summary>
        /// Closing price
        /// </summary>
        [JsonProperty("close")]
        public decimal ClosePrice { get; set; }

        /// <summary>
        /// Total amount of base currency traded within the timeframe
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }
    }
}
