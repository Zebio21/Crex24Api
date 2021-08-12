using System;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqMoneyTransfers: ReqBase
    {
        [JsonIgnore]
        public CrexMoneyTransferType TransferTypeEnum
        {
            get => CrexMoneyTransfer.TransferTypeStrToEnum(TransferType);
            set => TransferType = CrexMoneyTransfer.TransferTypeEnumToStr(value);
        }
        [JsonProperty("type")]
        public string TransferType { get; set; }

        [JsonProperty("currency")]
        public string[] CoinTickers { get; set; }

        [JsonProperty("from")]
        public DateTime? From { get; set; }

        [JsonProperty("till")]
        public DateTime? Till { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }
}
