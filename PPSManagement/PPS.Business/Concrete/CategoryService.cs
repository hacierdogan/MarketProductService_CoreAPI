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
    public class CategoryService : ICategoryService
    {
        protected ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }
        public async Task<List<Category>> GetAllCategoriesByParentId(int id)
        {
            return await _categoryRepository.GetAllCategoriesByParentId(id);
        }
        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryRepository.GetCategoryById(id);
        }
        public async Task<Category> CreateCategory(Category category)
        {
            return await _categoryRepository.CreateCategory(category);
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            return await _categoryRepository.UpdateCategory(category);
        }
        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }

        // Category Details
        public async Task<List<CategoryDetail>> GetAllCategoryDetails()
        {
            return await _categoryRepository.GetAllCategoryDetails();
        }
        public async Task<List<CategoryDetail>> GetAllCategoryDetailsByCategoryId(int categoryId)
        {
            return await _categoryRepository.GetAllCategoryDetailsByCategoryId(categoryId);
        }
        public async Task<CategoryDetail> GetCategoryDetailById(int id)
        {
            return await _categoryRepository.GetCategoryDetailById(id);
        }
        public async Task<CategoryDetail> CreateCategoryDetail(CategoryDetail categoryDetail)
        {
            return await _categoryRepository.CreateCategoryDetail(categoryDetail);
        }
        public async Task<CategoryDetail> UpdateCategoryDetail(CategoryDetail categoryDetail)
        {
            return await _categoryRepository.UpdateCategoryDetail(categoryDetail);
        }
        public async Task DeleteCategoryDetail(int id)
        {
            await _categoryRepository.DeleteCategoryDetail(id);
        }
    }
}
