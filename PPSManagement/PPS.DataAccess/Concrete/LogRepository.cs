using Microsoft.EntityFrameworkCore;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Concrete
{
    public class LogRepository : ILogRepository
    {
        public async Task<List<Log>> GetAllLogs()
        {
            using(var db=new DataContext())
            {
                return await db.Logs.ToListAsync();
            }
        }
        public async Task<Log> CreateLog(Log log)
        {
            using(var db=new DataContext())
            {
                db.Logs.Add(log);
                await db.SaveChangesAsync();
                return log;
            }
        }
        public async Task<Log> GetLogById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Logs.FindAsync(id);
            }
        }
    }
}
