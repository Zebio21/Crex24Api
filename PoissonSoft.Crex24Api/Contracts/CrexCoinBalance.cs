using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Coin balance
    /// </summary>
    public class CrexCoinBalance
    {
        /// <summary>
        /// Currency identifier, e.g. "BTC"
        /// </summary>
        [JsonProperty("currency")]
        public string Ticker { get; set; }

        /// <summary>
        /// Available balance (funds that can be withdrawn or used for trading)
        /// </summary>
        [JsonProperty("available")]
        public decimal Available { get; set; }

        /// <summary>
        /// Reserved balance (funds that are being used in active orders and, consequently, can’t be withdrawn or used elsewhere at the moment)
        /// </summary>
        [JsonProperty("reserved")]
        public decimal Reserved { get; set; }
    }
}
