using System.Runtime.Serialization;

namespace PoissonSoft.Crex24Api.Contracts.Enums
{
    /// <summary>
    /// Instrument state
    /// </summary>
    public enum InstrumentState
    {
        /// <summary>
        /// Unknown (erroneous) type
        /// </summary>
        Unknown,

        /// <summary>
        /// Working in a normal mode
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// Trading is suspended
        /// </summary>
        [EnumMember(Value = "suspended")]
        Suspended,

        /// <summary>
        /// Instrument is delisted
        /// </summary>
        [EnumMember(Value = "delisted")]
        Delisted,
    }
}
