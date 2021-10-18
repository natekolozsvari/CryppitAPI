using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class Favorite : Crypto
    {
        public int UserId { get; set; }
    }
}
