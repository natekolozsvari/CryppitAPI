using System;
using System.ComponentModel.DataAnnotations;

namespace CryppitBackend.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "name cannot exceed 50 characters")]
        public string Name { get; set; }

        public byte[] Salt { get; set; }

        [Required]
        public string  Password { get; set; }
        
        [Required]
        public double Balance { get; set; }
        public string JoinDate { get; set; }
    }
}
