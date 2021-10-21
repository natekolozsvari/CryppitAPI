//using CryppitBackend.Models;
//using Microsoft.AspNetCore.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace CryppitBackend.Services
//{
//    public class DailyCryptoService
//    {
//        public DailyCryptoService(IWebHostEnvironment webHostEnvironment)
//        {
//            WebHostEnvironment = webHostEnvironment;
//        }

//        public IWebHostEnvironment WebHostEnvironment { get; }

//        private string JsonFileName
//        {
//            get { return Path.Combine(Environment.CurrentDirectory, "Data", "daily.json"); }
//        }

        //public async Task<Crypto> GetDailyCrypto()
        //{
        //    DailyCrypto dailyCrypto;
        //    using (var jsonFileReader = File.OpenText(JsonFileName))
        //    {
        //        dailyCrypto = JsonSerializer.Deserialize<DailyCrypto>(jsonFileReader.ReadToEnd(),
        //            new JsonSerializerOptions
        //            {
        //                PropertyNameCaseInsensitive = true
        //            });
        //    }

//        public async Task<Crypto> GetDailyCrypto()
//        {
//            DailyCrypto dailyCrypto;
//            using (var jsonFileReader = File.OpenText(JsonFileName))
//            {
//                dailyCrypto = JsonSerializer.Deserialize<DailyCrypto>(jsonFileReader.ReadToEnd(),
//                    new JsonSerializerOptions
//                    {
//                        PropertyNameCaseInsensitive = true
//                    });
//            }

//            Crypto details;
//            if (dailyCrypto.Changed == UnixToDay(DateTimeOffset.Now.ToUnixTimeSeconds()))
//            {
//                details = dailyCrypto.Details;
//            }
//            else
//            {
//                details = await SetNewDailyCrypto();
//                File.WriteAllText(JsonFileName, JsonSerializer.Serialize(new DailyCrypto { Details = details, Changed = UnixToDay(DateTimeOffset.Now.ToUnixTimeSeconds()) }, new JsonSerializerOptions { WriteIndented = true })); ;
//            }
//            return details;
//        }

//        public async Task<Crypto> SetNewDailyCrypto()
//        {
//            string baseURL = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=1&page={GetRandomCoinIndex()}&sparkline=false";
//            Crypto cryptoDetail = null;
//            try
//            {
//                using (HttpClient client = new HttpClient())
//                {
//                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
//                    {
//                        using (HttpContent content = res.Content)
//                        {
//                            string data = await content.ReadAsStringAsync();
//                            Console.WriteLine(data);
//                            if (data != null)
//                            {
//                                cryptoDetail = JsonSerializer.Deserialize<Crypto[]>(data, new JsonSerializerOptions
//                                {
//                                    PropertyNameCaseInsensitive = true
//                                })[0];
//                            }
//                            else
//                            {
//                                Console.WriteLine("Data is null!");
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception exception)
//            {
//                Console.WriteLine(exception);

//            }
//            return cryptoDetail;
//        }

//        public long UnixToDay(long s)
//        {
//            return s / 60 / 60 / 24;
//        }

//        public int GetRandomCoinIndex()
//        {
//            var cryptosToChooseFrom = 1000;
//            var currentUnixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
//            var currentDay = (int)UnixToDay(currentUnixTime);
//            var rng = new Random(currentDay);
//            var dailyCryptoIndex = rng.Next(cryptosToChooseFrom);
//            Trace.WriteLine(dailyCryptoIndex);
//            return dailyCryptoIndex;
//        }
//    }
//}
