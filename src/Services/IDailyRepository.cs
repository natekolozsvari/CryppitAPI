using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public interface IDailyRepository
    {
        Task<DailyCrypto> GetDaily();
        DailyCrypto ChangeDaily(DailyCrypto newDaily);
    }
}
