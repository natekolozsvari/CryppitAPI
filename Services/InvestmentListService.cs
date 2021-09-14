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
    public class InvestmentListService
    {
        public InvestmentListService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "./Data", "investments.json"); }
        }

        public IEnumerable<Investment> GetInvestments(Guid id)
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var allInvestments = JsonSerializer.Deserialize<Investment[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                return allInvestments.Where(i => i.UserId == id);
            }
        }
    }
}
