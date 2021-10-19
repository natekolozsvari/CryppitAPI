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
        //public InvestmentListService InvestmentService { get; set; }
        public IInvestmentRepository InvestmentRepository { get; set; }

        public InvestmentListController(IInvestmentRepository repository)
        {
            //InvestmentService = investmentService;
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
        public void PostInvestment(string userId, Investment investment)
        {
            investment.UserId = userId;
            investment.Id = Guid.NewGuid().ToString("N");
            InvestmentRepository.Add(investment);
        }

        [HttpPut("{id}")]
        public void UpdateInvestment(string id, Investment investment)
        {
            InvestmentRepository.Update(investment);
        }

        [HttpDelete("{id}")]
        public void DeleteInvestment(string id)
        {
            InvestmentRepository.Delete(id);
        }


        
        public IActionResult Index()
        {
            return View();
        }
    }
}
