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
        public UserService UserService { get; }

        public UserController(UserService userService)
        {
            this.UserService = userService;
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
    }
}
