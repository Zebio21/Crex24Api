using System.Runtime.Serialization;


namespace PoissonSoft.Crex24Api.Contracts.Enums
{
    /// <summary>
    /// OHLCV data granularity
    /// </summary>
    public enum Granularity
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown,

        /// <summary>
        /// 1 minute
        /// </summary>
        [EnumMember(Value = "1m")]
        Minute_1,

        /// <summary>
        /// 3 minutes 
        /// </summary>
        [EnumMember(Value = "3m")]
        Minutes_3,

        /// <summary>
        /// 5 minutes 
        /// </summary>
        [EnumMember(Value = "5m")]
        Minutes_5,

        /// <summary>
        /// 15 minutes 
        /// </summary>
        [EnumMember(Value = "15m")]
        Minutes_15,

        /// <summary>
        /// 30 minutes 
        /// </summary>
        [EnumMember(Value = "30m")]
        Minutes_30,

        /// <summary>
        /// 1 hours
        /// </summary>
        [EnumMember(Value = "1h")]
        Hours_1,

        /// <summary>
        /// 4 hours  
        /// </summary>
        [EnumMember(Value = "4h")]
        Hours_4,

        /// <summary>
        /// 1 day
        /// </summary>
        [EnumMember(Value = "1d")]
        Day,

        /// <summary>
        ///  1 week
        /// </summary>
        [EnumMember(Value = "1w")]
        Week,

        /// <summary>
        /// 1 month
        /// </summary>
        [EnumMember(Value = "1mo")]
        Month,
    }
}
