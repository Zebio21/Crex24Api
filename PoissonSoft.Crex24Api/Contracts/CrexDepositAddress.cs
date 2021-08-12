using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Deposit Address object
    /// </summary>
    public class CrexDepositAddress
    {
        /// <summary>
        /// Cryptocurrency identifier
        /// </summary>
        [JsonProperty("currency")]
        public string CoinTicker { get; set; }

        /// <summary>
        /// Address of the wallet to send the cryptocurrency to
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Additional information (such as Payment ID, Message, Memo, etc.) that defines the destination
        /// of money transfer along with the address and should be specified when sending the deposit.
        /// If there’s no need to specify an additional information, the field contains the value null
        /// </summary>
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        /// <summary>
        /// Transport identifier
        /// </summary>
        [JsonProperty("transport")]
        public string Transport { get; set; }

    }
}
