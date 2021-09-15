using System.Text.Json.Serialization;

namespace CryppitBackend.Models
{
    public class CryptoDetail
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("market_data")]
        public MarketData MarketData { get; set; }

        public CryptoGraph Graph { get; set; }

        public Image Image { get; set; }
    }

    public class Image
    {
        public string Thumb { get; set; }
        public string Small { get; set; }
        public string Large { get; set; }
    }
}
