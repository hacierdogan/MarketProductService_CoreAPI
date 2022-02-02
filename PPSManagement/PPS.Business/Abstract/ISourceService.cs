using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface ISourceService
    {
        Task<List<Source>> GetAllSource();
        Task<Source> GetSourcebyId(int id);
        Task<Source> CreateSource(Source source);
        Task<Source> UpdateSource(Source source);
        Task DeleteSource(int id);
    }
}
