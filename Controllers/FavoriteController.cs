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
        public FavoriteService FavoriteService { get; set; }

        public FavoriteController(FavoriteService investmentService)
        {
            FavoriteService = investmentService;
        }

        [HttpGet]
        public IEnumerable<Crypto> GetFavorites()
        {
            return FavoriteService.GetFavorites();
        }

        [HttpPost]
        public void PostFavorite(Crypto favorite)
        {
            FavoriteService.AddFavorite(favorite);
        }

        [HttpDelete("{id}")]
        public void DeleteFavorite(string id)
        {
            FavoriteService.DeleteFavorite(id);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
