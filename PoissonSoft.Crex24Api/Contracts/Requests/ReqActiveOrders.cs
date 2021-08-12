using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqActiveOrders: ReqBase
    {
        [JsonProperty("instrument")]
        public string[] InstrumentTickers { get; set; }
    }
}
