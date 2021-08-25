using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqOrderTrades
    {
        [JsonProperty("id")]
        public long OrderId { get; set; }
    }
}
