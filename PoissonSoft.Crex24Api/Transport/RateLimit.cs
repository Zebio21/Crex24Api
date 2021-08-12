using System;
using System.Collections.Generic;
using System.Text;

namespace PoissonSoft.Crex24Api.Transport
{

    /// <summary>
    /// Rate limit (request number per time interval threshold)
    /// </summary>
    public class RateLimit
    {
        /// <summary>
        /// Time interval
        /// </summary>
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// Requests limit
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Default crex RateLimit
        /// </summary>
        public static RateLimit Default { get; } = new RateLimit
        {
            Interval = TimeSpan.FromSeconds(10),
            Limit = 60
        };
    }
}
