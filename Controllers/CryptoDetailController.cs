using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryppitBackend.Models;
using CryppitBackend.Services;

namespace CryppitBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoDetailController : Controller
    {
        public CryptoDetailService CryptoDetailService { get; set; }

        public CryptoDetailController(CryptoDetailService cryptoDetailService)
        {
            CryptoDetailService = cryptoDetailService;
        }

        [HttpGet("{cryptoId}")]
        public async Task<CryptoDetail> Get(string cryptoId)
        {
            return await CryptoDetailService.GetDetails(cryptoId);
        }


        public IActionResult Index()
        {
            return View();
        }

    }
}
