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
        public InvestmentListService InvestmentService { get; set; }

        public InvestmentListController(InvestmentListService investmentService)
        {
            InvestmentService = investmentService;
        }

        [HttpGet("{userid}")]
        public async Task<IEnumerable<Investment>> GetInvestments(string userId)
        {
            var investments = InvestmentService.GetInvestments(userId);
            var ids = new List<string>();
            foreach (var investment in investments)
            {
                ids.Add(investment.CryptoId);
            }
            var prices = await InvestmentService.GetPrices(ids);
            foreach (var investment in investments)
            {
                investment.CurrentPrice = prices[investment.CryptoId]["usd"];
            }
            return investments;
        }

        [HttpPost("{userid}")]
        public void PostInvestment(string userId, Investment investment)
        {
            investment.UserId = userId;
            investment.Id = Guid.NewGuid().ToString("N");
            InvestmentService.AddInvestment(userId, investment);
        }

        [HttpPut("{id}")]
        public void UpdateInvestment(string id, Investment investment)
        {
            InvestmentService.UpdateInvestment(id, investment);
        }

        [HttpDelete("{id}")]
        public void DeleteInvestment(string id)
        {
            InvestmentService.DeleteInvestment(id);
        }


        
        public IActionResult Index()
        {
            return View();
        }
    }
}
