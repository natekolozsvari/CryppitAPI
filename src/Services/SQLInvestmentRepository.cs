using CryppitBackend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public class SQLInvestmentRepository : IInvestmentRepository
    {
        private readonly AppDbContext context;

        public SQLInvestmentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Investment> Investments => context.Investments;
        
        public Investment Add(Investment investment)
        {
            context.Investments.Add(investment);
            context.SaveChanges();
            return investment;
        }

        public Investment Delete(string id)
        {
            Investment investment = context.Investments.Find(id);
            if (investment != null)
            {
                context.Investments.Remove(investment);
                context.SaveChanges();
            }
            return investment;
        }

        public IEnumerable<Investment> GetAllInvestments()
        {
            return context.Investments;
        }

        public Investment GetInvestment(string id)
        {
            return context.Investments.Find(id);
        }

        public IEnumerable<Investment> GetInvestmentsForUser(string userId)
        {
            return context.Investments.Where(investment => investment.UserId == userId);
        }
    
        public Investment Update(Investment investmentChanges)
        {
            context.Entry(GetInvestment(investmentChanges.Id)).State = EntityState.Detached;
            var investment = context.Investments.Attach(investmentChanges);
            investment.State = EntityState.Modified;
            context.SaveChanges();
            return investmentChanges;
        }

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
