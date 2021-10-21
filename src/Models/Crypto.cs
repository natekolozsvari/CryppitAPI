using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CryppitBackend.Models
{
    public class Crypto
    {
        [Key]
        public string FavoriteId { get; set; }

        public string UserId { get; set; }
      
        public string Id { get; set; }

        public string Symbol { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("current_price")]
        public double Value { get; set; }

        public string Image { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public double Change { get; set; }


        [JsonPropertyName("market_cap")]
        public double MarketCap { get; set; }

        [JsonPropertyName("high_24h")]
        public double High24H { get; set; }

        [JsonPropertyName("low_24h")]
        public double Low24H { get; set; }

        public double Ath { get; set; }

        [JsonPropertyName("total_volume")]
        public double TotalVolume { get; set; }
    }
}
