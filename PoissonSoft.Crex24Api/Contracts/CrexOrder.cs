using System;
using Newtonsoft.Json;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Serialization;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Order Object
    /// </summary>
    public class CrexOrder: ICloneable
    {
        /// <summary>
        /// Unique order identifier
        /// </summary>
        [JsonProperty("id")]
        public long Id { get; set; }

        /// <summary>
        /// Date and time of creation
        /// </summary>
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        /// <summary>
        /// Trade instrument identifier
        /// </summary>
        [JsonProperty("instrument")]
        public string InstrumentTicker { get; set; }

        /// <summary>
        /// Direction of trade
        /// </summary>
        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumExConverter), OrderSide.Unknown)]
        public OrderSide Side { get; set; }

        /// <summary>
        /// Order type
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumExConverter), OrderType.Unknown)]
        public OrderType OrderType { get; set; }

        /// <summary>
        /// Order status
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumExConverter), OrderType.Unknown)]
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Length of time over which the order will continue working before it’s cancelled
        /// </summary>
        [JsonProperty("timeInForce")]
        [JsonConverter(typeof(StringEnumExConverter), OrderType.Unknown)]
        public TimeInForce TimeInForce { get; set; }

        /// <summary>
        /// Initial price of the order. In case of market order, this field contains the value null
        /// </summary>
        [JsonProperty("price")]
        public decimal? Price { get; set; }

        /// <summary>
        /// Initial volume of the order
        /// </summary>
        [JsonProperty("volume")]
        public decimal InitialVolume { get; set; }

        /// <summary>
        /// Remaining volume of the order (volume that hasn’t been filled)
        /// </summary>
        [JsonProperty("remainingVolume")]
        public decimal Volume { get; set; }

        /// <summary>
        /// Stop-price (for stop-limit orders only; if the order is of different type, this field contains the value null)
        /// </summary>
        [JsonProperty("stopPrice")]
        public decimal? StopPrice { get; set; }

        /// <summary>
        /// Last time the order had undergone changes (remaining volume decreased, status changed, etc.).
        /// If this information is not available, the field contains the value null.
        /// </summary>
        [JsonProperty("lastUpdate")]
        public DateTimeOffset? LastUpdate { get; set; }

        /// <inheritdoc />
        public object Clone()
        {
            return new CrexOrder
            {
                Id = Id,
                Timestamp = Timestamp,
                InstrumentTicker = InstrumentTicker,
                OrderType = OrderType,
                Status = Status,
                TimeInForce = TimeInForce,
                Price = Price,
                InitialVolume = InitialVolume,
                Volume = Volume,
                StopPrice = StopPrice,
                LastUpdate = LastUpdate
            };
        }

    }
}
