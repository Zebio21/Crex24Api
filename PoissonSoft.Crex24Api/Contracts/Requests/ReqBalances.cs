using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqBalances
    {
        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public string[] CoinFilter { get; set; }

        [JsonProperty("nonZeroOnly", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NonZeroBalancesOnly { get; set; }
    }
}
