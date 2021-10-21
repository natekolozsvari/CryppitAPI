using CryppitBackend.Models;
using CryppitBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CryppitBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoGraphController : Controller
    {
            public CryptoGraphService CryptoService { get; set; }

            public CryptoGraphController(CryptoGraphService cryptoService)
            {
                CryptoService = cryptoService;
            }

            [HttpGet("{id}")]
            public async Task<CryptoGraph> Get(string id)
            {
                return await CryptoService.GetGraph(id);
            }

            public IActionResult Index()
            {
                return View();
            }
        }
    }
