using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqOrderTrades: ReqBase
    {
        [JsonProperty("id")]
        public ulong OrderId { get; set; }
    }
}
