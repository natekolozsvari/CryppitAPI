using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CryppitBackend.Models;
using Microsoft.AspNetCore.Hosting;

namespace CryppitBackend.Services
{
    public class CryptoDetailService
    {
        public async Task<CryptoDetail> GetDetails(string cryptoId)
        {
            string baseURL = $"https://api.coingecko.com/api/v3/coins/{cryptoId}";
            CryptoDetail cryptoDetail = null;
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
                                cryptoDetail = JsonSerializer.Deserialize<CryptoDetail>(data, new JsonSerializerOptions
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
            return cryptoDetail;
        }

        public CryptoDetailService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }
    }
}
