using System;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqTradeHistory
    {
        [JsonProperty("instrument")]
        public string InstrumentTicker { get; set; }

        [JsonProperty("from")]
        public DateTime? TimeFrom { get; set; }

        [JsonProperty("till")]
        public DateTime? TimeTill { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

    }
}
