using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class Crypto
    {
        public string Id { get; set; }

        public string Symbol { get; set; }
        public string Name { get; set; }

        public double Value { get; set; }

        public string Image { get; set; }

        public double Change { get; set; }

    }
}
