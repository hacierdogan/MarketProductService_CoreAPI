using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Abstract
{
    public interface ILogRepository
    {
        Task<List<Log>> GetAllLogs();
        Task<Log> GetLogById(int id);
        Task<Log> CreateLog(Log log);
    }
}
