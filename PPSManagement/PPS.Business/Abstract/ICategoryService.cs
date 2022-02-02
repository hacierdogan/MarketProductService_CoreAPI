using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<List<Category>> GetAllCategoriesByParentId(int id);
        Task<Category> GetCategoryById(int id);
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(int id);
        // Category Details
        Task<List<CategoryDetail>> GetAllCategoryDetails();
        Task<List<CategoryDetail>> GetAllCategoryDetailsByCategoryId(int categoryId);
        Task<CategoryDetail> GetCategoryDetailById(int id);
        Task<CategoryDetail> CreateCategoryDetail(CategoryDetail categoryDetail);
        Task<CategoryDetail> UpdateCategoryDetail(CategoryDetail categoryDetail);
        Task DeleteCategoryDetail(int id);
    }
}
