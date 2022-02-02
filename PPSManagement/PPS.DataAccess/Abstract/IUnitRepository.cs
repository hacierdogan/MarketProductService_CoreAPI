using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Abstract
{
    public interface IUnitRepository
    {
        Task<List<Unit>> GetAllUnits();
        Task<Unit> GetUnitById(int id);
        Task<Unit> CreateUnit(Unit unit);
        Task<Unit> UpdateUnit(Unit unit);
        Task DeleteUnit(int id);

        //unit details
        Task<List<UnitDetail>> GetAllUnitDetails();
        Task<List<UnitDetail>> GetAllUnitDetailsByUnitId(int unitId);
        Task<UnitDetail> GetUnitDetailById(int id);
        Task<UnitDetail> CreateUnitDetail(UnitDetail unitDetail);
        Task<UnitDetail> UpdateUnitDetail(UnitDetail unitDetail);
        Task DeleteUnitDetail(int id);
    }
}
