using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqOrderStatus
    {
        [JsonProperty("id")]
        public long[] OrderId { get; set; }
    }
}
