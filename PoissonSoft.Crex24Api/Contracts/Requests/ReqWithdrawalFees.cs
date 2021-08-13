using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqWithdrawalFees
    {
        [JsonProperty("currency")]
        public string WithdrawingCoinTicker { get; set; }
    }

}
