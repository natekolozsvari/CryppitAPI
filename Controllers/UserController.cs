using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
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


        [HttpGet("email")]
        public User GetUserByEmail(string email)
        {
            return SqlUserRepository.GetUserByEmail(email);
        }

        [HttpPost("login")]
        public User CheckPassword(User user)
        {
            var currentUser = GetUserByEmail(user.Email);
            if (currentUser.Password.Equals(HashPassword(user.Password, currentUser.Salt).Item2))
            {
                return currentUser;
            }
            return null;
        }


        [HttpPost]
        public void AddUser(User user)
        {
            var hashed = HashPassword(user.Password);
            user.Id = Guid.NewGuid().ToString("N");
            user.Salt = hashed.Item1;
            user.Password = hashed.Item2;
            user.Balance = 100000;
            user.JoinDate = DateTime.Now.Date.ToString("D");
            SqlUserRepository.Add(user);
        }


        [HttpPut("{id}")]
        public void ChangeBalance(string id, User user)
        {
            SqlUserRepository.Update(user);
        }


        private Tuple<byte[], string> HashPassword(string password, byte[] salt = null)
        {
            byte[] newSalt;
            if (salt == null)
            {
                newSalt = new byte[128 / 8];
                using (var rngCsp = new RNGCryptoServiceProvider())
                {
                    rngCsp.GetNonZeroBytes(newSalt);                
                }
            }
            else
            {
                newSalt = salt;
            }

            var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: newSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            Trace.WriteLine(hashedPassword);
            return Tuple.Create(newSalt, hashedPassword);
        }
    }
}
