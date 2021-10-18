using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    interface IDailyRepository
    {
        DailyCrypto GetDaily();
        DailyCrypto ChangeDaily();
    }
}
