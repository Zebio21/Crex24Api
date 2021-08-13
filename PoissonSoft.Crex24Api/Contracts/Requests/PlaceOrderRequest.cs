using Newtonsoft.Json;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Serialization;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    /// <summary>
    /// Place order request
    /// </summary>
    public class PlaceOrderRequest
    {
        /// <summary>
        /// Trade instrument for which the order should be placed, e.g. "ETH-BTC"
        /// </summary>
        [JsonProperty("instrument")]
        public string InstrumentTicker { get; set; }

        /// <summary>
        /// Order side, can have either of the two values
        /// </summary>
        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumExConverter), OrderSide.Unknown)]
        public OrderSide Side { get; set; }

        /// <summary>
        ///  Order type
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumExConverter), OrderType.Unknown)]
        public OrderType Type { get; set; }

        /// <summary>
        /// Sets the length of time over which the order will continue working before it’s cancelled
        /// </summary>
        [JsonProperty("timeInForce", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumExConverter), OrderType.Unknown)]
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        /// The amount of base currency to be bought or sold
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Order price.
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// The price in a stop-limit order that triggers the creation of a limit order
        /// </summary>
        [JsonProperty("stopPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? StopPrice { get; set; }

        /// <summary>
        /// Optional. The values of parameters price and stopPrice must be multiples of tickSize,
        /// and the value of parameter volume must be a multiple of volumeIncrement
        /// </summary>
        [JsonProperty("strictValidation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StrictValidation { get; set; }

    }
}
