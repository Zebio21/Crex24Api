using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqDepositAddress: ReqBase
    {
        [JsonProperty("currency")]
        public string CoinTicker { get; set; }

        [JsonProperty("transport")]
        public string Transport { get; set; }
    }
}
