using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class DailyCrypto
    {
        public Crypto Details { get; set; }

        public long Changed { get; set; }
    }
}
