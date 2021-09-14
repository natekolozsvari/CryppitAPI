using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class CryptoGraph
    {
        public List<double> Prices { get; set; }
        public List<int> Dates { get; set; }
    }
}
