using Microsoft.EntityFrameworkCore;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Concrete
{
    public class BrandRepository : IBrandRepository
    {
        public async Task<List<Brand>> GetAllBrands()
        {
            using(var db=new DataContext())
            {
                return await db.Brands.ToListAsync();
            }
        }
        public async Task<Brand> GetBrandById(int id)
        {
            using(var db=new DataContext())
            {
                return await db.Brands.FindAsync(id);
            }
        }      
        public async Task<Brand> CreateBrand(Brand brand)
        {
            using (var db = new DataContext())
            {
                db.Brands.Add(brand);
                await db.SaveChangesAsync();
                return brand;
            }
        }
        public async Task<Brand> UpdateBrand(Brand brand)
        {
            using (var db = new DataContext())
            {
                db.Brands.Update(brand);
                await db.SaveChangesAsync();
                return brand;
            }
        }
        public async Task DeleteBrand(int id)
        {
            using (var db = new DataContext())
            {
                var deletebrand = await GetBrandById(id);
                db.Brands.Remove(deletebrand);
                await db.SaveChangesAsync();
            }
        }
    }
}
