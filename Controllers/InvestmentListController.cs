using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public IEnumerable<Investment> Get(string userId)
        {
            var investments = InvestmentService.GetInvestments(userId);
            // add graph
            // add crypto details
            return investments;
        }

        [HttpPost("{userid}")]
        public void PostInvestment(string userId, Investment investment)
        {
            investment.UserId = userId;
            investment.Id = Guid.NewGuid().ToString("N");
            InvestmentService.AddInvestment(userId, investment);
        }

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
