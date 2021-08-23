using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Serialization;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// List of recent trades made with the specified instrument
    /// </summary>
    public class CrexRecentTrade
    {
        /// <summary>
        /// Price for which the base currency was bought or sold
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Trade volume (the amount of base currency that was bought or sold)
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Trade direction, can have either of the two values: "buy" or "sell"
        /// </summary>
        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumExConverter), OrderSide.Unknown)]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Date and time when the trade took place
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
    }
}
