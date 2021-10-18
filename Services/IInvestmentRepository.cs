using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    interface IInvestmentRepository
    {
        Investment GetInvestment(int id);
        IEnumerable<Investment> GetAllInvestments();
        IEnumerable<Investment> GetInvestmentsForUser(int userId);
        Investment Add(Investment investment);
        Investment Update(Investment investmentChanges);
        Investment Delete(int id);
    }
}
