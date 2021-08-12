using System.Runtime.Serialization;

namespace PoissonSoft.Crex24Api.Contracts.Enums
{
    /// <summary>
    /// Order status
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Unknown (erroneous) type
        /// </summary>
        Unknown,

        /// <summary>
        /// In the process of submission
        /// </summary>
        [EnumMember(Value = "submitting")]
        Submitting,

        /// <summary>
        /// Active, no trades have taken place yet
        /// </summary>
        [EnumMember(Value = "unfilledActive")]
        UnfilledActive,

        /// <summary>
        /// Part of the order is active, the other part has already been filled
        /// </summary>
        [EnumMember(Value = "partiallyFilledActive")]
        PartiallyFilledActive,

        /// <summary>
        /// The order has been filled and is no longer active
        /// </summary>
        [EnumMember(Value = "filled")]
        Filled,

        /// <summary>
        /// Cancelled, no trades had been completed
        /// </summary>
        [EnumMember(Value = "unfilledCancelled")]
        UnfilledCancelled,

        /// <summary>
        /// Cancelled being partially filled: part of the order has been filled, the other part has been cancelled
        /// </summary>
        [EnumMember(Value = "partiallyFilledCancelled")]
        PartiallyFilledCancelled,

        /// <summary>
        /// Stop-limit order is waiting to be triggered to place a limit order
        /// </summary>
        [EnumMember(Value = "waiting")]
        Waiting,
    }
}
