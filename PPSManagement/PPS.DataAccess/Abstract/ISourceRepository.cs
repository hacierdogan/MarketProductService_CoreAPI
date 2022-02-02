using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Abstract
{
    public interface ISourceRepository
    {
        Task<List<Source>> GetAllSource();
        Task<Source> GetSourceById(int id);
        Task<Source> CreateSource(Source source);
        Task<Source> UpdateSource(Source source);
        Task DeleteSource(int id);
    }
}
