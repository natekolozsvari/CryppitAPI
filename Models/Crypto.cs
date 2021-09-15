using System.Text.Json.Serialization;

namespace CryppitBackend.Models
{
    public class Crypto
    {
        public string Id { get; set; }

        public string Symbol { get; set; }
        public string Name { get; set; }

        [JsonPropertyName("current_price")]
        public double Value { get; set; }

        public string Image { get; set; }
        
        [JsonPropertyName("price_change_percentage_24h")]
        public double Change { get; set; }

    }
}
