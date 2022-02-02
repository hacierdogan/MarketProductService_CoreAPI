using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Abstract
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllBrands();
        Task<Brand> GetBrandById(int id);
        Task<Brand> CreateBrand(Brand brand);
        Task<Brand> UpdateBrand(Brand brand);
        Task DeleteBrand(int id);

    }
}
