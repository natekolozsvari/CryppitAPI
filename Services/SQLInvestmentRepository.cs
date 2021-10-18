using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var investment = context.Investments.Attach(investmentChanges);
            investment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return investmentChanges;
        }
    }
}
