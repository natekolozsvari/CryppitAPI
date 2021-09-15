using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CryppitBackend.Models;
using Microsoft.AspNetCore.Hosting;

namespace CryppitBackend.Services
{
    public class UserService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public UserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName => Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "users.json");
    }
}
