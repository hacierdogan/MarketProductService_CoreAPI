using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface ILogService
    {
        Task<List<Log>> GetAllLogs();
        Task<Log> GetLogById(int id);
        Task<Log> CreateLog(Log log);
    }
}
