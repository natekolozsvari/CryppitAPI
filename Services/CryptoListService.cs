using CryppitBackend.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public class CryptoListService
    {

            public async Task<IEnumerable<Crypto>> GetCryptos(int currentPage, int cryptoPerPage)
        {
            string baseURL = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={cryptoPerPage}&page={currentPage}&sparkline=false";
            Crypto[] cryptos = Array.Empty<Crypto>();
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
                                cryptos = JsonSerializer.Deserialize<Crypto[]>(data, new JsonSerializerOptions
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
            return cryptos;

        }
            public CryptoListService(IWebHostEnvironment webHostEnvironment)
            {
                WebHostEnvironment = webHostEnvironment;
            }

            public IWebHostEnvironment WebHostEnvironment { get; }
        }
}
