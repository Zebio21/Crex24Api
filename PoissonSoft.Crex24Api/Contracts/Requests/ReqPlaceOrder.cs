using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqPlaceOrder: ReqBase
    {
        [JsonProperty("instrument")]
        public string InstrumentTicker { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("timeInForce", NullValueHandling = NullValueHandling.Ignore)]
        public string TimeInForce { get; set; }

        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("stopPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? StopPrice { get; set; }

        [JsonProperty("strictValidation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StrictValidation { get; set; }

    }
}
