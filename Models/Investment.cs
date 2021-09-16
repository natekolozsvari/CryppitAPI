using System;
using System.Text.Json;
using System.Text.Json.Serialization;

﻿namespace CryppitBackend.Models
{
    public class Investment
    {
        public string Id { get; set; }

        [JsonIgnore]
        public CryptoDetail Crypto { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("crypto_id")]
        public string CryptoId { get; set; }

        [JsonPropertyName("price")]
        public double PriceBought { get; set; }

        [JsonPropertyName("current_price")]
        public double CurrentPrice { get; set; }
        public double Amount { get; set; }
        
        [JsonIgnore]
        public CryptoGraph Graph { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Investment>(this);

    }
}
