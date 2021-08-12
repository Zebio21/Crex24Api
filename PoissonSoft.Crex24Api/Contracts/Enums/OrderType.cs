using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PoissonSoft.Crex24Api.Contracts.Enums
{
    /// <summary>
    /// Order types
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// Unknown (erroneous) type
        /// </summary>
        Unknown,

        /// <summary>
        /// Limit Order
        /// </summary>
        [EnumMember(Value = "limit")]
        Limit,

        /// <summary>
        /// Market Order
        /// </summary>
        [EnumMember(Value = "market")]
        Market,

        /// <summary>
        /// Stop-limit Order
        /// </summary>
        [EnumMember(Value = "stopLimit")]
        StopLimit,

    }
}
