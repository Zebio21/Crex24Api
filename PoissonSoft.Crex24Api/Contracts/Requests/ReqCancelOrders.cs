using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqCancelOrders
    {
        [JsonProperty("ids", NullValueHandling = NullValueHandling.Ignore)]
        public long[] OrderIds { get; set; }

        [JsonProperty("instruments", NullValueHandling = NullValueHandling.Ignore)]
        public string[] InstrumentTickers { get; set; }
    }
}
