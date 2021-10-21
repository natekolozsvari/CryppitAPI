using System.Text.Json.Serialization;


namespace CryppitBackend.Models
{
    public class MarketData
    {
        [JsonPropertyName("current_price")]
        public CurrentPrice CurrentPrice { get; set; }

        public Ath Ath { get; set; }

        [JsonPropertyName("market_cap")]
        public MarketCap MarketCap { get; set; }

        [JsonPropertyName("total_volume")]
        public TotalVolume TotalVolume { get; set; }

        [JsonPropertyName("high_24h")]
        public High24H High24H { get; set; }

        [JsonPropertyName("low_24h")]
        public Low24H Low24H { get; set; }

        [JsonPropertyName("price_change_percentage_24h")]
        public double PriceChangePercentage24H{ get; set; }

    }

    public class CurrentPrice
    {
        public double Usd { get; set; }
    }

    public class Ath
    {
        public double Usd { get; set; }
    }

    public class MarketCap
    {
        public long Usd { get; set; }
    }

    public class TotalVolume
    {
        public long Usd { get; set; }
    }

    public class High24H
    {
        public double Usd { get; set; }
    }

    public class Low24H
    {
        public double Usd { get; set; }
    }
}
