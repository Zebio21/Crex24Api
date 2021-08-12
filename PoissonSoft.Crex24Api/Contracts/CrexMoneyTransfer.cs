using System;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    internal class CrexMoneyTransfer
    {
        /// <summary>
        /// Unique identifier of money transfer
        /// </summary>
        [JsonProperty("id")]
        public ulong Id { get; set; }

        /// <summary>
        /// Type of money transfer, can have either of the two values: "deposit" or "withdrawal"
        /// </summary>
        [JsonProperty("type")]
        public string TransferTypeStr
        {
            get => TransferTypeEnumToStr(TransferType);
            set => TransferType = TransferTypeStrToEnum(value);
        }
        [JsonIgnore]
        public CrexMoneyTransferType TransferType { get; set; }

        /// <summary>
        /// Cryptocurrency identifier
        /// </summary>
        [JsonProperty("currency")]
        public string CoinTicker { get; set; }


        /// <summary>
        /// Cryptocurrency wallet address. 
        /// In case of cryptocurrency deposit, this field contains the address of the CREX24 wallet associated with trader’s account. 
        /// In case of cryptocurrency withdrawal, this field contains the address of external wallet, to which the money were transferred from trader’s account.
        /// For fiat deposits and withdrawals, this field contains the value null. The field also contains the value null for cryptocurrency deposits and withdrawals, 
        /// if the information about the wallet address is unavailable
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }

        /// <summary>
        /// Additional information (such as Payment ID, Message, Memo, etc.) that was specified along with the wallet address.
        /// For fiat deposits and withdrawals, this field contains the value null. The field also contains the value null for cryptocurrency deposits and withdrawals, 
        /// if such information is not unavailable
        /// </summary>
        [JsonProperty("paymentId")]
        public string PaymentId { get; set; }

        /// <summary>
        /// The amount of currency that was deposited or withdrawn
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// The amount of fee charged for money transfer. If this information is not available, the field contains the value null
        /// </summary>
        [JsonProperty("fee")]
        public decimal? Fee { get; set; }

        /// <summary>
        /// Identifier of the transaction in the cryptocurrency blockchain. 
        /// For fiat deposits and withdrawals, this field contains the value null. The field also contains the value null for cryptocurrency deposits and withdrawals, 
        /// if the information about the transaction ID is unavailable
        /// </summary>
        [JsonProperty("txId")]
        public string TxId { get; set; }

        /// <summary>
        /// Date and time when the money transfer was initiated
        /// </summary>
        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date and time when the money transfer was processed. If this information is not available or the money transfer hasn’t been processed yet, the field contains the value null
        /// </summary>
        [JsonProperty("processedAt")]
        public DateTime? ProcessedAt { get; set; }

        /// <summary>
        /// The number of blockchain confirmations the cryptocurrency deposit is required to receive before the funds are credited to the account, or the number of confirmations 
        /// the cryptocurrency withdrawal is required to receive before it is considered successful.
        /// In case of fiat deposits and withdrawals, this field contains the value null
        /// </summary>
        [JsonProperty("confirmationsRequired")]
        public int? ConfirmationsRequired { get; set; }

        /// <summary>
        /// Current number of blockchain confirmations of the cryptocurrency deposit/withdrawal (in case of fiat deposits and withdrawals, the field contains the value null) 
        /// </summary>
        [JsonProperty("confirmationCount")]
        public int? ConfirmationCount { get; set; }

        /// <summary>
        /// Money transfer status
        /// </summary>
        [JsonProperty("status")]
        public string TransferStatusStr
        {
            get => TransferStatusEnumToStr(TransferStatus);
            set => TransferStatus = TransferStatusStrToEnum(value);
        }
        [JsonIgnore]
        public CrexMoneyTransferStatus TransferStatus { get; set; }

        /// <summary>
        /// Error description (only for money transfers with status "failed", in other cases the field contains the value null)
        /// </summary>
        [JsonProperty("errorDescription")]
        public string ErrorDescription { get; set; }


        public static string TransferTypeEnumToStr(CrexMoneyTransferType trType)
        {
            switch (trType)
            {
                case CrexMoneyTransferType.Deposit: return "deposit";
                case CrexMoneyTransferType.Withdrawal: return "withdrawal";
                default: return null;
            }
        }

        public static CrexMoneyTransferType TransferTypeStrToEnum(string trType)
        {
            switch (trType)
            {
                case "deposit": return CrexMoneyTransferType.Deposit;
                case "withdrawal": return CrexMoneyTransferType.Withdrawal;
                default: return CrexMoneyTransferType.Unknown;
            }
        }



        private static string TransferStatusEnumToStr(CrexMoneyTransferStatus trStatus)
        {
            switch (trStatus)
            {
                case CrexMoneyTransferStatus.Pending: return "pending";
                case CrexMoneyTransferStatus.Success: return "success";
                case CrexMoneyTransferStatus.Failed: return "failed";
                default: return null;
            }
        }

        private static CrexMoneyTransferStatus TransferStatusStrToEnum(string trStatus)
        {
            switch (trStatus)
            {
                case "pending": return CrexMoneyTransferStatus.Pending;
                case "success": return CrexMoneyTransferStatus.Success;
                case "failed": return CrexMoneyTransferStatus.Failed;
                default: return CrexMoneyTransferStatus.Unknown;
            }
        }

    }

    internal enum CrexMoneyTransferType
    {
        Unknown = 0,
        Deposit = 1,
        Withdrawal = 2,
    }

    internal enum CrexMoneyTransferStatus
    {
        Unknown = 0,

        /// <summary>
        /// transfer is in progress
        /// </summary>
        Pending = 1,

        /// <summary>
        /// completed successfully
        /// </summary>
        Success = 2,

        /// <summary>
        /// aborted at some point (money will be credited back to the account of origin)
        /// </summary>
        Failed = 3,
    }
}
