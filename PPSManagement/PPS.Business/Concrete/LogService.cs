using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class LogService : ILogService
    {
        protected ILogRepository _logrepository;
        public LogService(ILogRepository logrepository)
        {
            _logrepository = logrepository;
        }
       
        public async Task<List<Log>> GetAllLogs()
        {
            return await _logrepository.GetAllLogs();
        }
        public async Task<Log> CreateLog(Log log)
        {
            return await _logrepository.CreateLog(log);
        }
        public async Task<Log> GetLogById(int id)
        {
            return await _logrepository.GetLogById(id);
        }
    }
}
