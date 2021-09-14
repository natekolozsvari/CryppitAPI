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

        [HttpGet("{id}")]
        public IEnumerable<Investment> Get(Guid id)
        {
            var investments = InvestmentService.GetInvestments(id);
            // add graph
            // add crypto details
            return investments;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
