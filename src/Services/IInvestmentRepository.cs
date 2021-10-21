using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public interface IInvestmentRepository
    {
        public IQueryable<Investment> Investments { get; }
        Investment GetInvestment(string id);
        IEnumerable<Investment> GetAllInvestments();
        IEnumerable<Investment> GetInvestmentsForUser(string userId);
        Investment Add(Investment investment);
        Investment Update(Investment investmentChanges);
        Investment Delete(string id);
        Task<Dictionary<string, Dictionary<string, double>>> GetPrices(List<string> ids);
    }
}
