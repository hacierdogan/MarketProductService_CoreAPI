using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class SourceService : ISourceService
    {
        protected ISourceRepository _sourceRepository;
        public SourceService(ISourceRepository sourceRepository)
        {
            _sourceRepository = sourceRepository;
        }

        public async Task<List<Source>> GetAllSource()
        {
            return await _sourceRepository.GetAllSource();
        }
        public async Task<Source> GetSourcebyId(int id)
        {
            return await _sourceRepository.GetSourceById(id);
        }
        public async Task<Source> CreateSource(Source source)
        {
            return await _sourceRepository.CreateSource(source);
        }
        public async Task<Source> UpdateSource(Source source)
        {
            return await _sourceRepository.UpdateSource(source);
        }
        public async Task DeleteSource(int id)
        {
            await _sourceRepository.DeleteSource(id);
        }

    }
}
