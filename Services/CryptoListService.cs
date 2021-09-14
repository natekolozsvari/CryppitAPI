using CryppitBackend.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public class CryptoListService
    {

        private string jsonString;
            public async Task<IEnumerable<Crypto>> GetCryptos(int currentPage, int cryptoPerPage)
        {
            string baseURL = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page={cryptoPerPage}&page={currentPage}&sparkline=false";
            Crypto[] cryptos = Array.Empty<Crypto>();
            //Have your api call in try/catch block.
            try
            {
                //Now we will have our using directives which would have a HttpClient 
                using (HttpClient client = new HttpClient())
                {
                    //Now get your response from the client from get request to baseurl.
                    //Use the await keyword since the get request is asynchronous, and want it run before next asychronous operation.
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        //Now we will retrieve content from our response, which would be HttpContent, retrieve from the response Content property.
                        using (HttpContent content = res.Content)
                        {
                            //Retrieve the data from the content of the response, have the await keyword since it is asynchronous.
                            string data = await content.ReadAsStringAsync();
                            //If the data is not null, parse the data to a C# object, then create a new instance of PokeItem.
                            if (data != null)
                            {
                                //Parse your data into a object.
                                cryptos = JsonSerializer.Deserialize<Crypto[]>(data, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                });

                            }
                            else
                            {
                                //If data is null log it into console.
                                Console.WriteLine("Data is null!");
                            }
                        }
                    }
                }
                //Catch any exceptions and log it into the console.
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


            //public IEnumerable<Crypto> GetCryptos()
            //{
            //    using (var jsonFileReader = File.OpenText(JsonFileName))
            //    {
            //        return JsonSerializer.Deserialize<Crypto[]>(jsonFileReader.ReadToEnd(),
            //            new JsonSerializerOptions
            //            {
            //                PropertyNameCaseInsensitive = true
            //            });
            //    }
            //}
        }
}
