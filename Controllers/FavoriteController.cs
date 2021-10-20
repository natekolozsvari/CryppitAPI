using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CryppitBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavoriteController : Controller
    {
        public IFavoriteRepository FavoriteRepository { get; set; }

        public FavoriteController(IFavoriteRepository favoriteRepository)
        {
            FavoriteRepository = favoriteRepository;
        }

        [HttpGet("{id}")]
        public IEnumerable<Crypto> GetFavorites(string id)
        {
            return FavoriteRepository.GetAllFavorites(id);
        }

        [HttpPost("{id}")]
        public void PostFavorite(Favorite favorite, string id)
        {
            favorite.UserId = id;
            FavoriteRepository.Add(favorite);
        }

        [HttpDelete("{id}")]
        public void DeleteFavorite(string id)
        {
            FavoriteRepository.Delete(id);
        }
    }
}
