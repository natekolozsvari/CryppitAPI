using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public class SQLDailyRepository : IDailyRepository
    {
        private readonly AppDbContext context;

        public SQLDailyRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DailyCrypto ChangeDaily(DailyCrypto newDaily)
        {
            DailyCrypto oldDaily = context.Daily.FirstOrDefault();
            if (oldDaily != null)
            {
                context.Daily.Remove(oldDaily);
            }
            context.Daily.Add(newDaily);
            context.SaveChanges();
            return newDaily;
        }

        public async Task<DailyCrypto> GetDaily()
        {
            var currentDaily = context.Daily.FirstOrDefault();
            Trace.WriteLine(currentDaily);
            var today = UnixToDay(DateTimeOffset.Now.ToUnixTimeSeconds());
            if (currentDaily != null && currentDaily.Changed == today)
            {
                return currentDaily;
            }
            else
            {
                var newDailyDetails = await SetNewDailyCrypto();
                var newDaily = new DailyCrypto
                {
                    Id = newDailyDetails.Id,
                    Changed = today
                };
                return ChangeDaily(newDaily);
            }
        }

        public async Task<Crypto> SetNewDailyCrypto()
        {
            string baseURL = $"https://api.coingecko.com/api/v3/coins/markets?vs_currency=usd&order=market_cap_desc&per_page=1&page={GetRandomCoinIndex()}&sparkline=false";
            Crypto cryptoDetail = null;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseURL))
                    {
                        using (HttpContent content = res.Content)
                        {
                            string data = await content.ReadAsStringAsync();
                            Console.WriteLine(data);
                            if (data != null)
                            {
                                cryptoDetail = JsonSerializer.Deserialize<Crypto[]>(data, new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                })[0];
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

        public long UnixToDay(long s)
        {
            return s / 60 / 60 / 24;
        }

        public int GetRandomCoinIndex()
        {
            var cryptosToChooseFrom = 1000;
            var currentUnixTime = DateTimeOffset.Now.ToUnixTimeSeconds();
            var currentDay = (int)UnixToDay(currentUnixTime);
            var rng = new Random(currentDay);
            var dailyCryptoIndex = rng.Next(cryptosToChooseFrom);
            return dailyCryptoIndex;
        }
    }
}
