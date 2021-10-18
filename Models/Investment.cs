using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

﻿namespace CryppitBackend.Models
{
    public class Investment
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public CryptoDetail Crypto { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string CryptoId { get; set; }

        [Required]
        public double PriceBought { get; set; }

        [Required]
        public double CurrentPrice { get; set; }

        [Required]
        public double Amount { get; set; }
        
        public CryptoGraph Graph { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Investment>(this);

    }
}
