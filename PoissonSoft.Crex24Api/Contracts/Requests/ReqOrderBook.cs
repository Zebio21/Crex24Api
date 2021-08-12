using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqOrderBook: ReqBase
    {
        [JsonProperty("instrument")]
        public string InstrumentTicker { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
