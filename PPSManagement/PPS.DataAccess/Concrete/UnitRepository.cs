using Microsoft.EntityFrameworkCore;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Concrete
{
    public class UnitRepository : IUnitRepository
    {
        public async Task<List<Unit>> GetAllUnits()
        {
            using (var db = new DataContext())
            {
                return await db.Units.ToListAsync();
            }
        }
        public async Task<Unit> GetUnitById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Units.FindAsync(id);
            }
        }
        public async Task<Unit> CreateUnit(Unit unit)
        {
            using(var db=new DataContext())
            {
                db.Units.Add(unit);
                await db.SaveChangesAsync();
                return unit;
            }
        }
        public async Task<Unit> UpdateUnit(Unit unit)
        {
            using(var db=new DataContext())
            {
                db.Units.Update(unit);
                await db.SaveChangesAsync();
                return unit;

            }
        }
        public async Task DeleteUnit(int id)
        {
            using (var db = new DataContext())
            {
                var deleteunit = await GetUnitById(id);
                db.Units.Remove(deleteunit);
                await db.SaveChangesAsync();
            }
        }

        // Unit Details
        public async Task<List<UnitDetail>> GetAllUnitDetails()
        {
            using (var db = new DataContext())
            {
                return await db.UnitDetails.ToListAsync();
            }
        }
        public async Task<List<UnitDetail>> GetAllUnitDetailsByUnitId(int unitId)
        {
            using (var db = new DataContext())
            {
                return await db.UnitDetails.Where(w => w.UnitId == unitId).ToListAsync();
            }
        }
        public async Task<UnitDetail> GetUnitDetailById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.UnitDetails.FindAsync(id);
            }
        }
        public async Task<UnitDetail> CreateUnitDetail(UnitDetail unitDetail)
        {
            using (var db = new DataContext())
            {
                db.UnitDetails.Add(unitDetail);
                await db.SaveChangesAsync();
                return unitDetail;
            }
        }
        public async Task<UnitDetail> UpdateUnitDetail(UnitDetail unitDetail)
        {
            using (var db = new DataContext())
            {
                db.UnitDetails.Update(unitDetail);
                await db.SaveChangesAsync();
                return unitDetail;
            }
        }
        public async Task DeleteUnitDetail(int id)
        {
            using (var db = new DataContext())
            {
                var deleteunitdetail = await GetUnitDetailById(id);
                db.UnitDetails.Remove(deleteunitdetail);
                await db.SaveChangesAsync();
            }
        }
    }
}
