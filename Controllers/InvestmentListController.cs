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

        [HttpGet("{userId}")]
        public async Task<IEnumerable<Investment>> GetInvestments(string userId)
        {
            var investments = InvestmentService.GetInvestments(userId);
            var cryptoIds = investments.Select(investment => investment.CryptoId).ToList();
            var prices = await InvestmentService.GetPrices(cryptoIds);
            investments.ToList()
                .ForEach(investment => investment.CurrentPrice = prices[investment.CryptoId]["usd"]);
            return investments;
        }

        [HttpPost("{userId}")]
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
