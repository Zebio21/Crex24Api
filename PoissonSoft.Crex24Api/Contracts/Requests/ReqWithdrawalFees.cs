using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqWithdrawalFees: ReqBase
    {
        [JsonProperty("currency")]
        public string WithdrawingCoinTicker { get; set; }
    }

}
