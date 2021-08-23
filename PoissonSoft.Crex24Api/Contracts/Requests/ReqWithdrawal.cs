using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqWithdrawal
    {
        [JsonProperty("currency")]
        public string CoinTicker { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        [JsonProperty("includeFee", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IncludeFee { get; set; }

        [JsonProperty("transport", NullValueHandling = NullValueHandling.Ignore)]
        public string Transport { get; set; }
    }
}
