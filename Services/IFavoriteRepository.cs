using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryppitBackend.Models;

namespace CryppitBackend.Services
{
    public interface IFavoriteRepository
    {
        IEnumerable<Favorite> GetAllFavorites(int userId);
        Favorite Add(Favorite favorite);
        Favorite Delete(string id);
    }
}
