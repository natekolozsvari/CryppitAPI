using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryppitBackend.Models;

namespace CryppitBackend.Services
{
    public interface IUserRepository
    {
        User GetUSer(int id);
        IEnumerable<User> GetAllUsers();
        User Add(User user);
        User Update(User user);
        User Delete(int id);
    }
}
