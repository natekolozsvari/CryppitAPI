using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    [Keyless]
    public class Favorite : Crypto
    {
        [Required]
        public string UserId { get; set; }
    }
}
