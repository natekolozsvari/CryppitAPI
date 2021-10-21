using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public void PostFavorite(string id, Crypto favorite)
        {
            favorite.UserId = id;
            favorite.FavoriteId = Guid.NewGuid().ToString("N");
            FavoriteRepository.Add(favorite);
        }

        [HttpDelete("{cryptoId}/{userId}")]
        public void DeleteFavorite(string cryptoId, string userId)
        {
            FavoriteRepository.Delete(cryptoId, userId);
        }
    }
}