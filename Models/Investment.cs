using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class Investment
    {
        public CryptoDetail Crypto { get; set; }

        [JsonPropertyName("user_id")]
        public Guid UserId { get; set; }

        [JsonPropertyName("crypto_id")]
        public string CryptoId { get; set; }

        [JsonPropertyName("price")]
        public double PriceBought { get; set; }
        public double Amount { get; set; }
        public CryptoGraph Graph { get; set; }
    }
}
