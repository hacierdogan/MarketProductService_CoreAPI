using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class SessionService : ISessionService
    {
        protected ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public async Task<List<Session>> TGetAll()
        {
            return await _sessionRepository.GetAll();
        }

        public async Task<Session> TGetById(int id)
        {
            return await _sessionRepository.GetById(id);
        }
               
        public async Task<Session> TCreate(Session t)
        {
            return await _sessionRepository.Create(t);
        }
        public async Task<Session> TUpdate(Session t)
        {
            return await _sessionRepository.Update(t);
        }
        public async Task TDelete(int id)
        {
            await _sessionRepository.Delete(id);
        }
    }
}
