using CryppitBackend.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        //private string JsonFileName
        //{
        //    get { return Path.Combine(Environment.CurrentDirectory, "Data", "investments.json"); }
        //}

        //public IEnumerable<Investment> GetInvestments(string id)
        //{
        //    Investment[] allInvestments;
        //    using (var jsonFileReader = File.OpenText(JsonFileName))
        //    {
        //        allInvestments = JsonSerializer.Deserialize<Investment[]>(jsonFileReader.ReadToEnd(),
        //            new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true
        //            });
        //    }
        //    return allInvestments.Where(i => i.UserId == id);
        //}

        //public void AddInvestment(string id, Investment investment)
        //{
        //    var allInvestments = new List<Investment>();
        //    using (var jsonFileReader = File.OpenText(JsonFileName))
        //    {
        //        allInvestments = JsonSerializer.Deserialize<List<Investment>>(jsonFileReader.ReadToEnd(),
        //            new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true
        //            });
        //    }
        //    allInvestments.Add(investment);
        //    File.WriteAllText(JsonFileName, JsonSerializer.Serialize(allInvestments, new JsonSerializerOptions { WriteIndented = true }));
        //}

        //public void UpdateInvestment(string id, Investment investment)
        //{
        //    Investment[] allInvestments;
        //    using (var jsonFileReader = File.OpenText(JsonFileName))
        //    {
        //        allInvestments = JsonSerializer.Deserialize<Investment[]>(jsonFileReader.ReadToEnd(),
        //            new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true
        //            });
        //    }
        //    var selectedInvestment = allInvestments.Where(i => i.Id == id).First();
        //    allInvestments[Array.IndexOf(allInvestments, selectedInvestment)] = investment;
        //    File.WriteAllText(JsonFileName, JsonSerializer.Serialize(allInvestments, new JsonSerializerOptions { WriteIndented = true }));
        //}

        //public void DeleteInvestment(string id)
        //{
        //    Investment[] allInvestments;
        //    using (var jsonFileReader = File.OpenText(JsonFileName))
        //    {
        //        allInvestments = JsonSerializer.Deserialize<Investment[]>(jsonFileReader.ReadToEnd(),
        //            new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true
        //            });
        //        allInvestments = allInvestments.Where(i => i.Id != id).ToArray();
        //    }
        //    File.WriteAllText(JsonFileName, JsonSerializer.Serialize(allInvestments, new JsonSerializerOptions { WriteIndented = true }));
        //}

        public async Task<Dictionary<string, Dictionary<string, double>>> GetPrices(List<string> ids)
        {
            var url = $"https://api.coingecko.com/api/v3/simple/price?ids={String.Join("%2C", ids)}&vs_currencies=usd";
            var prices = new Dictionary<string, Dictionary<string, double>>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(url))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                prices = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, double>>>(data, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });
                            }
                            else
                            {
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return prices;
        }
    }
}
