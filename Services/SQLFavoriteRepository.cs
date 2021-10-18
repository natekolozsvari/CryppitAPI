using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryppitBackend.Models;

namespace CryppitBackend.Services
{
    public class SQLFavoriteRepository : IFavoriteRepository
    {
        readonly AppDbContext _context;

        public SQLFavoriteRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Favorite> GetAllFavorites()
        {
            throw new NotImplementedException();
        }

        public Favorite Add(Favorite favorite)
        {
            throw new NotImplementedException();
        }

        public Favorite Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
