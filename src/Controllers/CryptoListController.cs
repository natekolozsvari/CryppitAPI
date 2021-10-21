using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryppitBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoListController : Controller
    {
        public CryptoListService CryptoService { get; set; }

        public CryptoListController(CryptoListService cryptoService)
        {
            CryptoService = cryptoService;
        }

        [HttpGet("{page}/{per}")]
        public async Task<IEnumerable<Crypto>> Get(int page, int per)
        {
            return await CryptoService.GetCryptos(page, per);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
