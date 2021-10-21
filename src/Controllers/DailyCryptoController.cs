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
    public class DailyCryptoController : Controller
    {
        public DailyCryptoService CryptoService { get; set; }

        public DailyCryptoController(DailyCryptoService cryptoService)
        {
            CryptoService = cryptoService;
        }

        [HttpGet]
        public async Task<Crypto> Get()
        {
            return await CryptoService.GetDailyCrypto();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
