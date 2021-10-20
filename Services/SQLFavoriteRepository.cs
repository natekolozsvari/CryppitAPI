using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public IEnumerable<Crypto> GetAllFavorites(string userId)
        {
            return _context.Favorites.Where(favorite =>favorite.UserId == userId);
        }

        public Crypto Add(Crypto favorite)
        {
            _context.Favorites.Add(favorite);
            _context.SaveChanges();
            return favorite;
        }

        public Crypto Delete(string id)
        {
            Crypto favorite = _context.Favorites.Find(id);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                _context.SaveChanges();
            }

            return favorite;
        }
    }
}
