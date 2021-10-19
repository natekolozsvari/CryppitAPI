using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CryppitBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository SqlUserRepository { get; set; }

        public UserController(IUserRepository userRepository)
        {
            this.SqlUserRepository = userRepository;
        }


        [HttpGet("{email}")]
        public User GetUserByEmail(string email)
        {
            return SqlUserRepository.GetUserByEmail(email);
        }


        [HttpPost]
        public void AddUser(User user)
        {
            user.Id = Guid.NewGuid().ToString("N");
            user.Balance = 100000;
            user.JoinDate = DateTime.Now.Date.ToString("D");
            SqlUserRepository.Add(user);
        }


        [HttpPut("{id}")]
        public void ChangeBalance(string id, User user)
        {
            SqlUserRepository.Update(user);
        }



        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);                
            }
            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashedPassword;
        }

    }
}
