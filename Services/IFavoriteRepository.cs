using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryppitBackend.Models;

namespace CryppitBackend.Services
{
    interface IFavoriteRepository
    {
        IEnumerable<Favorite> GetAllFavorites();
        Favorite Add(Favorite favorite);
        Favorite Delete(int id);
    }
}
