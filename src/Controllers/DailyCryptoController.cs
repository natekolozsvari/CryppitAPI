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
        public IDailyRepository DailyRepository{ get; set; }

        public DailyCryptoController(IDailyRepository dailyRepository)
        {
            DailyRepository = dailyRepository;
        }

        [HttpGet]
        public async Task<DailyCrypto> Get()
        {
            return await DailyRepository.GetDaily();
        }
    }
}
