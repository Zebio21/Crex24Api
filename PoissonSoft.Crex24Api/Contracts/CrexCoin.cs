using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Crex Currency object
    /// </summary>
    public class CrexCoin
    {
        /// <summary>
        /// Unique identifier of the currency, e.g. "BTC"
        /// </summary>
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        /// <summary>
        /// Currency name, e.g. "Bitcoin"
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Reports whether the currency is fiat
        /// </summary>
        [JsonProperty("isFiat")]
        public bool IsFiat { get; set; }

        /// <summary>
        /// Contains the value false if deposits for the currency are not accepted at the moment
        /// </summary>
        [JsonProperty("depositsAllowed")]
        public bool DepositsAllowed { get; set; }

        /// <summary>
        /// The number of blockchain confirmations the deposit is required to receive before the funds
        /// are credited to the account (for cryptocurrencies only; in case of fiat currency, the field contains the value null)
        /// </summary>
        [JsonProperty("depositConfirmationCount")]
        public int? DepositConfirmationCount { get; set; }

        /// <summary>
        /// Minimum deposit threshold (for cryptocurrencies only; in case of fiat currency, the field contains the value null)
        /// If the deposit doesn't meet the minimum threshold, the funds will not be credited to the account until the moment,
        /// when in the result of following deposits, their total amount will have reached the threshold
        /// </summary>
        [JsonProperty("minDeposit")]
        public decimal? MinDeposit { get; set; }

        /// <summary>
        /// Contains the value false if withdrawals are not currently available for the currency
        /// </summary>
        [JsonProperty("withdrawalsAllowed")]
        public bool WithdrawalsAllowed { get; set; }

        /// <summary>
        /// Precision of withdrawal amount, expressed in the number of decimal places (digits to the right of a decimal point)
        /// "withdrawalPrecision": 6,
        /// </summary>
        [JsonProperty("withdrawalPrecision")]
        public int WithdrawalPrecision { get; set; }

        /// <summary>
        /// Minimum withdrawal amount
        /// "minWithdrawal": 1.0,
        /// </summary>
        [JsonProperty("minWithdrawal")]
        public decimal? MinWithdrawal { get; set; }

        /// <summary>
        /// Maximum withdrawal amount
        /// "maxWithdrawal": 500000000.0,
        /// </summary>
        [JsonProperty("maxWithdrawal")]
        public decimal? MaxWithdrawal { get; set; }

        /// <summary>
        /// Reports whether the currency is delisted
        /// </summary>
        [JsonProperty("isDelisted")]
        public bool IsDelisted { get; set; }

        /// <summary>
        /// Available transport blockchains for cryptocurrency deposits and withdrawals.
        /// If the cryptocurrency doesn't have transports, the field contains the value null
        /// </summary>
        [JsonProperty("transports")]
        public string[] Transports { get; set; }
    }
}
