﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Models
{
    public class User
    {
        public string Name { get; set; }
        public string  Password { get; set; }
        public Guid Id { get; set; }

        public double Balance { get; set; }

        public DateTime JoinDate { get; set; }
    }
}