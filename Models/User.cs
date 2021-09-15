using System;

namespace CryppitBackend.Models
{
    public class User
    {
        public string Name { get; set; }
        public string  Password { get; set; }
        public int Id { get; set; }

        public double Balance { get; set; }

        public DateTime JoinDate { get; set; }
    }
}
