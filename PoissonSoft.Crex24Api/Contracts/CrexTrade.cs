using System;
using Newtonsoft.Json;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Serialization;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Crex Trade object
    /// </summary>
    public class CrexTrade
    {
        /// <summary>
        /// Unique* trade identifier
        /// * If a user acts both as a buyer and a seller in the same trade, the response will
        /// contain two results for such trade - one with information for the buyer and the other
        /// with information for the seller - both with the same trade ID
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Identifier of the order that generated the trade
        /// </summary>
        [JsonProperty("orderId")]
        public long OrderId { get; set; }

        /// <summary>
        /// Date and time when the trade took place
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Trade instrument identifier
        /// </summary>
        [JsonProperty("instrument")]
        public string CrexInstrument { get; set; }

        /// <summary>
        /// Trade direction, can have either of the two values: "buy" or "sell"
        /// </summary>
        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumExConverter), OrderSide.Unknown)]
        public OrderSide Side { get; set; }

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
        /// The amount of fee charged (negative value means rebate)
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Fee/rebate currency
        /// </summary>
        [JsonProperty("feeCurrency")]
        public string FeeCurrencyTicker { get; set; }

    }
}
