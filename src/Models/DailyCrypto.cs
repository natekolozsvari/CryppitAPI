﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    [Keyless]
    public class DailyCrypto
    {
        [Required]
        public Crypto Details { get; set; }

        [Required]
        public long Changed { get; set; }
    }
}