using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqInstrumentFilter
    {
        [JsonProperty("instrument")]
        public string[] InstrumentTickers { get; set; }
    }
}
