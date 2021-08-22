using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PoissonSoft.Crex24Api.Contracts.Enums;
using PoissonSoft.Crex24Api.Contracts.Serialization;

namespace PoissonSoft.Crex24Api.Contracts.Requests
{
    internal class ReqOHLCVData
    {
        /// <summary>
        /// Trade instrument for which the OHLCV data is requested
        /// </summary>
        [JsonProperty("instrument")]
        public string InstrumentTicker { get; set; }

        /// <summary>
        /// OHLCV data granularity
        /// </summary>
        [JsonProperty("granularity")]
        [JsonConverter(typeof(StringEnumExConverter), Granularity.Unknown)]
        public Granularity Granularity { get; set; }

        /// <summary>
        /// Optional. Maximum number of results per call. Accepted values: 1 - 1000. Default is set 100
        /// </summary>
        [JsonProperty("limit", NullValueHandling = NullValueHandling.Ignore)]
        public int? Limit { get; set; }
    }
}
