using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryppitBackend.Models;

namespace CryppitBackend.Services
{
   public interface IFavoriteRepository
    {
        IEnumerable<Crypto> GetAllFavorites(string userId);
        Crypto Add(Crypto favorite);
        Crypto Delete(string cryptoId, string userId);
    }
}
