using System;

namespace CryppitBackend.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string  Password { get; set; }
        public string Id { get; set; }
        public double Balance { get; set; }
        public string JoinDate { get; set; }
    }
}
