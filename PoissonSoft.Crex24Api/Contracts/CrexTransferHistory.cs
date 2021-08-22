using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Returns an array of MoneyTransfer objects, sorted from newest to oldest
    /// </summary>
    public class CrexTransferHistory
    {
        /// <summary>
        /// Unique identifier of money transfer
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Type of money transfer, can have either of the two values: "deposit" or "withdrawal"
        /// </summary>
        [JsonProperty("type")]
        public string TransferType { get; set; }

        /// <summary>
        /// Cryptocurrency identifier
        /// </summary>
        [JsonProperty("currency")]
        public string CoinTickers { get; set; }

        /// <summary>
        /// Cryptocurrency identifier used to pay the withdrawal commission
        /// </summary>
        [JsonProperty("feeCurrency")]
        public string FeeCurrency { get; set; }

        /// <summary>
        /// Cryptocurrency wallet address.
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Additional information (such as Payment ID, Message, Memo, etc.) that was specified along with the wallet address.
        /// </summary>
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        /// <summary>
        /// Transport identifier
        /// </summary>
        [JsonProperty("transport")]
        public string Transport { get; set; }

        /// <summary>
        /// The amount of currency that was deposited or withdrawn
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The amount of fee charged for money transfer. If this information is not available, the field contains the value null
        /// </summary>
        [JsonProperty("fee")]
        public decimal Fee { get; set; }

        /// <summary>
        /// Identifier of the transaction in the cryptocurrency blockchain.
        /// </summary>
        [JsonProperty("txId")]
        public string TxId { get; set; }

        /// <summary>
        /// Date and time when the money transfer was initiated
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the money transfer was processed.
        /// </summary>
        [JsonProperty("processedAt")]
        public DateTime ProcessedAt { get; set; }

        /// <summary>
        /// The number of blockchain confirmations the cryptocurrency deposit is required to receive before the funds are credited to the account,
        /// or the number of confirmations the cryptocurrency withdrawal is required to receive before it is considered successful.
        /// </summary>
        [JsonProperty("confirmationsRequired")]
        public int ConfirmationsRequired { get; set; }

        /// <summary>
        /// Current number of blockchain confirmations of the cryptocurrency deposit/withdrawal
        /// </summary>
        [JsonProperty("confirmationCount")]
        public int ConfirmationCount { get; set; }

        /// <summary>
        /// Money transfer status, can have one of the following values:
        /// "pending" - transfer is in progress;
        /// "success" - completed successfully;
        /// "failed" - aborted at some point (money will be credited back to the account of origin)
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Error description (only for money transfers with status "failed", in other cases the field contains the value null)
        /// </summary>
        [JsonProperty("errorDescription")]
        public string ErrorDescription { get; set; }
    }
}
