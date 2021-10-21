using CryppitBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryppitBackend.Services
{
    public class SQLDailyRepository : IDailyRepository
    {
        private readonly AppDbContext context;

        public SQLDailyRepository(AppDbContext context)
        {
            this.context = context;
        }

        public DailyCrypto ChangeDaily(DailyCrypto newDaily)
        {
            DailyCrypto oldDaily = context.Daily.FirstOrDefault();
            if (oldDaily != null)
            {
                context.Daily.Remove(oldDaily);
            }
            context.Daily.Add(newDaily);
            context.SaveChanges();
            return newDaily;
        }

        public DailyCrypto GetDaily()
        {
            return context.Daily.FirstOrDefault();
        }


    }
}
