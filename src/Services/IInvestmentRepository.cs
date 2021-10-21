using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    interface IInvestmentRepository
    {
        Investment GetInvestment(string id);
        IEnumerable<Investment> GetAllInvestments();
        IEnumerable<Investment> GetInvestmentsForUser(string userId);
        Investment Add(Investment investment);
        Investment Update(Investment investmentChanges);
        Investment Delete(string id);
    }
}
