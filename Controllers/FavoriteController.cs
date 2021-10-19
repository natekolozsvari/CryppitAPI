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
        public IEnumerable<Crypto> GetFavorites(int id)
        {
            return FavoriteRepository.GetAllFavorites(id);
        }

        [HttpPost]
        public void PostFavorite(Favorite favorite)
        {
            FavoriteRepository.Add(favorite);
        }

        [HttpDelete("{id}")]
        public void DeleteFavorite(string id)
        {
            FavoriteRepository.Delete(id);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
