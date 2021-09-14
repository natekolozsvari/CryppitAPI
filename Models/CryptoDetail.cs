using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class CryptoDetail
    {
        public string Id { get; set; }

        public string Symbol { get; set; }
        public string Name { get; set; }

        public double Value { get; set; }
        public double MarketCap { get; set; }
        public double High24 { get; set; }
        public double Low24 { get; set; }

        public double AllTimeHigh { get; set; }
        public double TotalValue { get; set; }

        public CryptoGraph Graph { get; set; }


        public string Image { get; set; }

        public double Change { get; set; }
    }
}
