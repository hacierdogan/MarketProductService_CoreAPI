using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class UnitService : IUnitService
    {
        private IUnitRepository _unitRepository;
        public UnitService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<List<Unit>> GetAllUnits()
        {
            return await _unitRepository.GetAllUnits();
        }
        public async Task<Unit> GetUnitById(int id)
        {
            return await _unitRepository.GetUnitById(id);
        }
        public async Task<Unit> CreateUnit(Unit unit)
        {
            return await _unitRepository.CreateUnit(unit);
        }
        public async Task<Unit> UpdateUnit(Unit unit)
        {
            return await _unitRepository.UpdateUnit(unit);
        }
        public async Task DeleteUnit(int id)
        {
            await _unitRepository.DeleteUnit(id);
        }

        // Unit details
        public async Task<List<UnitDetail>> GetAllUnitDetails()
        {
            return await _unitRepository.GetAllUnitDetails();
        }
        public async Task<List<UnitDetail>> GetAllUnitDetailsByUnitId(int unitId)
        {
            return await _unitRepository.GetAllUnitDetailsByUnitId(unitId);
        }
        public async Task<UnitDetail> GetUnitDetailById(int id)
        {
            return await _unitRepository.GetUnitDetailById(id);
        }
        public async Task<UnitDetail> CreateUnitDetail(UnitDetail unitDetail)
        {
            return await _unitRepository.CreateUnitDetail(unitDetail);
        }
        public async Task<UnitDetail> UpdateUnitDetail(UnitDetail unitDetail)
        {
            return await _unitRepository.UpdateUnitDetail(unitDetail);
        }
        public async Task DeleteUnitDetail(int id)
        {
            await _unitRepository.DeleteUnitDetail(id);
        }
    }
}
