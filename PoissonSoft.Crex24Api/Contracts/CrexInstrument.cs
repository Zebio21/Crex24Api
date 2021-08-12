using Newtonsoft.Json;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Serialization;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Crex Instrument object
    /// </summary>
    public class CrexInstrument
    {
        /// <summary>
        /// Unique identifier of the instrument, e.g. "LTC-BTC" for trading in LTC/BTC pair
        /// </summary>
        [JsonProperty("symbol")]
        public string InstrumentTicker { get; set; }

        /// <summary>
        /// Base currency of the instrument
        /// </summary>
        [JsonProperty("baseCurrency")]
        public string BaseCoinTicker { get; set; }

        /// <summary>
        /// Quote currency of the instrument
        /// </summary>
        [JsonProperty("quoteCurrency")]
        public string QuoteCoinTicker { get; set; }

        /// <summary>
        /// Currency in which the fee is charged (rebate is paid), when trading the instrument
        /// </summary>
        [JsonProperty("feeCurrency")]
        public string FeeCoinTicker { get; set; }

        /// <summary>
        /// Trading fee schedule that is applied to the instrument
        /// </summary>
        [JsonProperty("feeSchedule")]
        public string FeeSchedule { get; set; }

        /// <summary>
        /// The minimum price movement of the instrument (the smallest price increment of an order placed for the instrument)
        /// </summary>
        [JsonProperty("tickSize")]
        public decimal? TickSize { get; set; }

        /// <summary>
        /// Minimum price of an order placed for the instrument
        /// </summary>
        [JsonProperty("minPrice")]
        public decimal? MinPrice { get; }

        /// <summary>
        /// Maximum price of an order placed for the instrument
        /// </summary>
        [JsonProperty("maxPrice")]
        public decimal? MaxPrice { get; }

        /// <summary>
        /// The smallest increment of volume of an order placed for the instrument
        /// (i.e., volume of a new order must be multiple of this value)
        /// </summary>
        [JsonProperty("volumeIncrement")]
        public decimal? VolumeIncrement { get; }

        /// <summary>
        /// Minimum volume of an order placed for the instrument
        /// </summary>
        [JsonProperty("minVolume")]
        public decimal? MinVolume { get; }

        /// <summary>
        /// Maximum volume of an order placed for the instrument
        /// </summary>
        [JsonProperty("maxVolume")]
        public decimal? MaxVolume { get; }

        /// <summary>
        /// Minimum notional value (volume expressed in quote currency) of an order placed for the instrument
        /// </summary>
        [JsonProperty("minQuoteVolume")]
        public decimal? MinQuoteVolume { get; }

        /// <summary>
        /// Maximum notional value (volume expressed in quote currency) of an order placed for the instrument
        /// </summary>
        [JsonProperty("maxQuoteVolume")]
        public decimal? MaxQuoteVolume { get; }

        /// <summary>
        /// Array of order types supported by the instrument
        /// </summary>
        [JsonProperty("supportedOrderTypes",
            ItemConverterType = typeof(StringEnumExConverter),
            ItemConverterParameters = new object[] { OrderType.Unknown })]
        public OrderType[] SupportedOrderTypes { get; set; }

        /// <summary>
        /// Instrument state
        /// </summary>
        [JsonProperty("state")]
        [JsonConverter(typeof(StringEnumExConverter), InstrumentState.Unknown)]
        public InstrumentState State { get; set; }

    }
}
