using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqWithdraw
    {
        /// <summary>
        /// Currency identifier
        /// </summary>
        [JsonProperty("currency")]
        public string CoinTicker { get; set; }

        /// <summary>
        /// Withdrawal amount (the precision is limited to a number of decimal places
        /// specified in the withdrawalPrecision field of the Currency, the value is
        /// rounded automatically to meet the precision limitation)
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Crypto address to which the money will be transferred
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Optional. Additional information (such as Payment ID, Message, Memo, etc.)
        /// that specifies the destination of money transfer along with the address.
        /// If this information is not required or not supported by the cryptocurrency,
        /// the parameter should be omitted
        /// </summary>
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        /// <summary>
        /// Currency identifier to be used to pay the commission
        /// </summary>
        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        /// <summary>
        /// Optional. Sets whether the specified amount includes fee
        /// </summary>
        [JsonProperty("includeFee")]
        public bool? IncludeFee { get; set; }

        /// <summary>
        /// Optional. Transport identifier. If the parameter is not specified
        /// and currency has multiple transports, the default transport will be used
        /// </summary>
        [JsonProperty("transport")]
        public string Transport { get; set; }
    }
}
