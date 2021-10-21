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

        [HttpPost("detail/{id}")]
        public void PostFavoriteDetails(string id, CryptoDetail favorite)
        {
            var newFav = new Crypto
            {
                Id = favorite.Id,
                Symbol = favorite.Symbol,
                Name = favorite.Name,
                Value = favorite.MarketData.CurrentPrice.Usd,
                Image = favorite.Image.Small,
                Change = favorite.MarketData.PriceChangePercentage24H,
                MarketCap = favorite.MarketData.MarketCap.Usd,
                High24H = favorite.MarketData.High24H.Usd,
                Low24H = favorite.MarketData.Low24H.Usd,
                Ath = favorite.MarketData.Ath.Usd,
                TotalVolume = favorite.MarketData.TotalVolume.Usd
            };
            newFav.UserId = id;
            newFav.FavoriteId = Guid.NewGuid().ToString("N");
            FavoriteRepository.Add(newFav);
        }

        [HttpDelete("{cryptoId}/{userId}")]
        public void DeleteFavorite(string cryptoId, string userId)
        {
            FavoriteRepository.Delete(cryptoId, userId);
        }
    }
}