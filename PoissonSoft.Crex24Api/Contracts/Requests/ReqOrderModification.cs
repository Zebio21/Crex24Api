using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqOrderModification
    {
        [JsonProperty("id")]
        public long OrderId { get; set; }

        [JsonProperty("newPrice", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? NewPrice { get; set; }

        [JsonProperty("newVolume", NullValueHandling = NullValueHandling.Ignore)]
        public decimal? NewVolume { get; set; }

        [JsonProperty("strictValidation", NullValueHandling = NullValueHandling.Ignore)]
        public bool? StrictValidation { get; set; }
    }
}
