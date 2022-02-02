using Microsoft.EntityFrameworkCore;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Concrete
{
    public class SourceRepository : ISourceRepository
    {
        

        public async Task<List<Source>> GetAllSource()
        {
            using (var db = new DataContext())
            {
                return await db.Sources.ToListAsync();
            }
        }
        public async Task<Source> GetSourceById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Sources.FindAsync(id);
            }
        }
        public async Task<Source> CreateSource(Source source)
        {
            using (var db = new DataContext())
            {
                db.Sources.Add(source);
                await db.SaveChangesAsync();
                return source;
            }
        }
        public async Task<Source> UpdateSource(Source source)
        {
            using (var db = new DataContext())
            {
                db.Sources.Update(source);
                await db.SaveChangesAsync();
                return source;
            }
        }
        public async Task DeleteSource(int id)
        {
            using (var db = new DataContext())
            {
                var deletesource = await GetSourceById(id);
                db.Sources.Remove(deletesource);
                await db.SaveChangesAsync();
            }
        }
    }
}
