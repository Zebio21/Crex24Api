using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqCurrencies : ReqBase
    {
        [JsonProperty("filter")]
        public string[] CoinTickers { get; set; }
    }

}
