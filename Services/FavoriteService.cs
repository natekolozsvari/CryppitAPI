using CryppitBackend.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public class FavoriteService
    {

        public IWebHostEnvironment WebHostEnvironment { get; }

        public FavoriteService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName => Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "favorites.json");

        public IEnumerable<Crypto> GetFavorites()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Crypto[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public void AddFavorite(Crypto favorite)
        {
            var favoriteList = new List<Crypto>();
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                favoriteList = JsonSerializer.Deserialize<List<Crypto>>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            favoriteList.Add(favorite);
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(favoriteList, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void DeleteFavorite(string id)
        {
            Crypto[] allFavorites;
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                allFavorites = JsonSerializer.Deserialize<Crypto[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                allFavorites = allFavorites.Where(i => i.Id != id).ToArray();
            }
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(allFavorites, new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}
