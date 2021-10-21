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

        public IEnumerable<User> GetUsers()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public void AddUser(User user)
        {
            var userList = new List<User>();
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                userList = JsonSerializer.Deserialize<List<User>>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            userList.Add(user);
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void ChangeBalance(string id, User user)
        {
            User[] userList;
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                userList = JsonSerializer.Deserialize<User[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            var selectedUser = userList?.First(i => i.Id == id);
            userList[Array.IndexOf(userList, selectedUser)] = user;
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
