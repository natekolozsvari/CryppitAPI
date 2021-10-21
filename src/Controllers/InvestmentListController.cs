using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentListController : Controller
    {
        public IInvestmentRepository InvestmentRepository { get; set; }

        public InvestmentListController(IInvestmentRepository repository)
        {
            InvestmentRepository = repository;
        }

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Investment>> GetInvestments(string userId)
        {
            var investments = InvestmentRepository.GetInvestmentsForUser(userId);
            var cryptoIds = investments.Select(investment => investment.CryptoId).ToList();
            var prices = await InvestmentRepository.GetPrices(cryptoIds);
            investments.ToList()
                .ForEach(investment => investment.CurrentPrice = prices[investment.CryptoId]["usd"]);
            return investments;
        }

        [HttpPost("{userId}")]
        public Investment PostInvestment(string userId, Investment investment)
        {
            investment.UserId = userId;
            var existingInv = InvestmentRepository.GetInvestmentsForUser(userId).Where(inv => inv.CryptoId == investment.CryptoId);
            if (existingInv.Count() > 0)
            {
                investment.PriceBought += existingInv.First().PriceBought;
                investment.Amount += existingInv.First().Amount;
                return UpdateInvestment(existingInv.First().Id, investment);
            }
            else
            {
                investment.Id = Guid.NewGuid().ToString("N");
                return InvestmentRepository.Add(investment);
            }
        }

        [HttpPut("{id}")]
        public Investment UpdateInvestment(string id, Investment investment)
        {
            investment.Id = id;
            return InvestmentRepository.Update(investment);
        }

        [HttpDelete("{id}")]
        public Investment DeleteInvestment(string id)
        {
            return InvestmentRepository.Delete(id);
        }
    }
}
