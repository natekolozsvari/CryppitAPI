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
            get { return Path.Combine(Environment.CurrentDirectory, "Data", "investments.json"); }
        }

        public IEnumerable<Investment> GetInvestments(string id)
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

        public void AddInvestment(string id, Investment investment)
        {
            var allInvestments = new List<Investment>();
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                allInvestments = JsonSerializer.Deserialize<List<Investment>>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
            allInvestments.Add(investment);
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(allInvestments, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void UpdateInvestment(string id, Investment investment)
        {
            Investment selectedInvestment;
            Investment[] allInvestments;
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                allInvestments = JsonSerializer.Deserialize<Investment[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                selectedInvestment = allInvestments.Where(i => i.Id == id).First();
            }
            allInvestments[Array.IndexOf(allInvestments, selectedInvestment)] = investment;
            File.WriteAllText(JsonFileName, JsonSerializer.Serialize(allInvestments, new JsonSerializerOptions { WriteIndented = true }));

        }
    }
}
