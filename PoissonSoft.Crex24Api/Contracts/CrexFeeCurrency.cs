using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Fee for currency withdrawal.
    /// </summary>
    public class CrexFeeCurrency
    {
        /// <summary>
        /// Currency identifier
        /// </summary>
        [JsonProperty("feeCurrency")]
        public string CrexCoin { get; set; }

        /// <summary>
        /// Fee amount
        /// </summary>
        [JsonProperty("amount")]
        public decimal FeeAmount { get; set; }
    }
}
