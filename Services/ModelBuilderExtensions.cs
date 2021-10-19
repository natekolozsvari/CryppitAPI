using CryppitBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Email = "john@doe.com",
                    Name = "John Doe",
                    Password = "johndoe",
                    Id = "c784662e0c27497eb4337cb0b2109823",
                    Balance = 1964.21,
                    JoinDate = "Wednesday, September 15, 2021"
                }
            );
        }
    }
}
