﻿using System.Runtime.Serialization;

namespace PoissonSoft.Crex24Api.Contracts.Enums
{
    /// <summary>
    /// Time In Force
    /// </summary>
    public enum TimeInForce
    {
        /// <summary>
        /// Unknown (erroneous) type
        /// </summary>
        Unknown,

        /// <summary>
        /// Good Til Canceled
        /// An order will be on the book unless the order is canceled.
        /// </summary>
        [EnumMember(Value = "GTC")]
        GTC,

        /// <summary>
        /// Immediate Or Cancel
        /// An order will try to fill the order as much as it can before the order expires.
        /// </summary>
        [EnumMember(Value = "IOC")]
        IOC,

        /// <summary>
        /// Fill or Kill
        /// An order will expire if the full order cannot be filled upon execution.
        /// </summary>
        [EnumMember(Value = "FOK")]
        FOK,
    }
}
