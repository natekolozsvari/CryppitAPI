using CryppitBackend.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public class CryptoGraphService
    {
        public async Task<CryptoGraph> GetGraph(string id)
        {
            string baseURL = $"https://api.coingecko.com/api/v3/coins/{id}/market_chart?vs_currency=usd&days=30&interval=daily";
            CryptoGraph cryptoGraph = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            if (data != null)
                            {
                                cryptoGraph = JsonSerializer.Deserialize<CryptoGraph>(data, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });
                            }
                            else
                            {
                                Trace.WriteLine("Data is null!");
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return cryptoGraph;

        }
        public CryptoGraphService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

    }
}
