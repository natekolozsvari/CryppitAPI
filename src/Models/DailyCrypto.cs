using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class DailyCrypto
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [Required]
        public long Changed { get; set; }
    }
}
