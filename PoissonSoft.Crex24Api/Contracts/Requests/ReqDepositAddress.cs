using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqDepositAddress
    {
        [JsonProperty("currency")]
        public string CoinTicker { get; set; }

        [JsonProperty("transport", NullValueHandling = NullValueHandling.Ignore)]
        public string Transport { get; set; }
    }
}
