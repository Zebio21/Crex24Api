using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace PoissonSoft.Crex24Api.Contracts
{
    /// <summary>
    /// Order Book object
    /// </summary>
    public class CrexOrderBook
    {
        /// <summary>
        /// Bids
        /// </summary>
        [JsonProperty("buyLevels")]
        public PriceLevel[] Bids { get; set; }

        /// <summary>
        /// Asks
        /// </summary>
        [JsonProperty("sellLevels")]
        public PriceLevel[] Asks { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return
                $"{(Asks?.Any() == true ? Asks.Min(l => l.Price).ToString(CultureInfo.InvariantCulture) : "?")} / " +
                $"{(Bids?.Any() == true ? Bids.Max(l => l.Price).ToString(CultureInfo.InvariantCulture) : "?")}";
        }
    }

    /// <summary>
    /// Price level
    /// </summary>
    public class PriceLevel
    {
        /// <summary>
        /// Price
        /// </summary>
        [JsonProperty("price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Volume
        /// </summary>
        [JsonProperty("volume")]
        public decimal Volume { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Price} х [{Volume}]";
        }
    }
}
