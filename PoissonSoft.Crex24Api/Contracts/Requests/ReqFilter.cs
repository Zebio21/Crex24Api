using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqFilter
    {
        [JsonProperty("filter")]
        public string[] FilterItems { get; set; }
    }

}
