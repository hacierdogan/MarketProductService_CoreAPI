using Microsoft.EntityFrameworkCore;
using PPS.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
       
        public async Task<List<T>> GetAll()
        {
            using (var db = new DataContext())
            {
                return await db.Set<T>().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Set<T>().FindAsync(id);
            }
        }

        public async Task<T> Create(T t)
        {
            using (var db = new DataContext())
            {
                db.Add(t);
                await db.SaveChangesAsync();
                return t;
            }
        }

        public async Task<T> Update(T t)
        {
            using (var db = new DataContext())
            {
                db.Update(t);
                await db.SaveChangesAsync();
                return t;
            }
        }

        public async Task Delete(int id)
        {
            using (var db = new DataContext())
            {
                var deleteItem = await GetById(id);
                db.Remove(deleteItem);
                await db.SaveChangesAsync();
            }
        }

    }
}
