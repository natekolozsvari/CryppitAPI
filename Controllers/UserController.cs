using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CryppitBackend.Models;
using CryppitBackend.Services;

namespace CryppitBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public SQLUserRepository SqlUserRepository { get; set; }

        public UserController(SQLUserRepository userRepository)
        {
            this.SqlUserRepository = userRepository;
        }


        [HttpGet]
        public IEnumerable<User> Get()
        {
            return UserService.GetUsers();
        }


        [HttpPost]
        public void AddUser(User user)
        {
            user.Id = Guid.NewGuid().ToString("N");
            user.Balance = 100000;
            user.JoinDate = DateTime.Now.Date.ToString("D");
            UserService.AddUser(user);
        }


        [HttpPut("{id}")]
        public void ChangeBalance(string id, User user)
        {
            UserService.ChangeBalance(id, user);
        }
    }
}
