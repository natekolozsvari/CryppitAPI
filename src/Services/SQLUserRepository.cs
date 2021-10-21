using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryppitBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace CryppitBackend.Services
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public SQLUserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public User GetUser(string id)
        {
            return _context.Users.Find(id);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(user => user.Email == email);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Update(User userChanges)
        {
            var user = _context.Users.Attach(userChanges);
            user.State = EntityState.Modified;
            _context.SaveChanges();
            return userChanges;
        }

        public User Delete(string id)
        {
            User user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return user;
        }
    }
}
