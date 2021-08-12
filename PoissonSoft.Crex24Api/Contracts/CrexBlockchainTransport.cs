using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Detailed information about transport blockchain for cryptocurrency
    /// </summary>
    public class CrexBlockchainTransport
    {
        /// <summary>
        /// Transport identifier
        /// "name": "ERC20",
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Transport full name
        /// "fullName": "Ethereum",
        /// </summary>
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Currency identifier
        /// "currency": "USDT",
        /// </summary>
        [JsonProperty("currency")]
        public string CoinTicker { get; set; }


        /// <summary>
        /// Contains the value false if deposits for the transport are not accepted at the moment
        /// "depositsAllowed": true,
        /// </summary>
        [JsonProperty("depositsAllowed")]
        public bool DepositsAllowed { get; set; }

        /// <summary>
        /// Contains the value false if withdrawals are not currently available for the transport
        /// "withdrawalsAllowed": true,
        /// </summary>
        [JsonProperty("withdrawalsAllowed")]
        public bool WithdrawalsAllowed { get; set; }

        /// <summary>
        /// The number of blockchain confirmations the deposit is required to receive before the funds are credited to the account
        /// "depositConfirmationCount": 12,
        /// </summary>
        [JsonProperty("depositConfirmationCount")]
        public int DepositConfirmationCount { get; set; }

        /// <summary>
        /// Minimum deposit threshold
        /// "minDeposit": 30.0,
        /// </summary>
        [JsonProperty("minDeposit")]
        public decimal MinDeposit { get; set; }

        /// <summary>
        /// Minimum withdrawal amount
        /// "minWithdrawal": 1.0,
        /// </summary>
        [JsonProperty("minWithdrawal")]
        public decimal MinWithdrawal { get; set; }

        /// <summary>
        /// Maximum withdrawal amount
        /// "maxWithdrawal": 500000000.0,
        /// </summary>
        [JsonProperty("maxWithdrawal")]
        public decimal MaxWithdrawal { get; set; }

        /// <summary>
        /// Precision of withdrawal amount, expressed in the number of decimal places (digits to the right of a decimal point)
        /// "withdrawalPrecision": 6,
        /// </summary>
        [JsonProperty("withdrawalPrecision")]
        public int WithdrawalPrecision { get; set; }

        /// <summary>
        /// Contains the value true if transport is used by default for currency
        /// "default": true,
        /// </summary>
        [JsonProperty("default")]
        public bool IsDefault { get; set; }

        /// <summary>
        /// An array of objects each representing a possible currency and amount for withdrawal fee payout
        /// </summary>
        [JsonProperty("withdrawalFees")]
        public CrexFeeCurrency[] WithdrawalFees { get; set; }
    }
}
