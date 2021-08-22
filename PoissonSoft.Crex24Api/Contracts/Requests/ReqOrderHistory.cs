using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqOrderHistory
    {
        [JsonProperty("instrument")]
        public string[] InstrumentTicker { get; set; }

        [JsonProperty("from")]
        public DateTime? From { get; set; }

        [JsonProperty("till")]
        public DateTime? Till { get; set; }

        [JsonProperty("limit")]
        public ushort? Limit { get; set; }
    }
}
