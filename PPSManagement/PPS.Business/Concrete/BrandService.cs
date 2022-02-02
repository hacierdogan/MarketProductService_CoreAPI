using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class BrandService : IBrandService
    {
        protected IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<Brand>> GetAllBrands()
        {
            return await _brandRepository.GetAllBrands();
        }
        public async Task<Brand> GetBrandById(int id)
        {
            return await _brandRepository.GetBrandById(id);
        }
        public async Task<Brand> CreateBrand(Brand brand)
        {
            return await _brandRepository.CreateBrand(brand);
        }
        public async Task<Brand> UpdateBrand(Brand brand)
        {
            return await _brandRepository.UpdateBrand(brand);
        }
        public async Task DeleteBrand(int id)
        {
            await _brandRepository.DeleteBrand(id);
        }

    }
}
