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
            return _context.Favorites;
        }

        public Favorite Add(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            _context.SaveChanges();
            return favorite;
        }

        public Favorite Delete(int id)
        {
            Favorite favorite = _context.Favorites.Find(id);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                _context.SaveChanges();
            }

            return favorite;
        }
    }
}
