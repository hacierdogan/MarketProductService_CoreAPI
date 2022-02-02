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
    public class CategoryRepository : ICategoryRepository
    {
        public async Task<List<Category>> GetAllCategories()
        {
            using (var db = new DataContext())
            {
                return await db.Categories.ToListAsync();
            }
        }
        public async Task<List<Category>> GetAllCategoriesByParentId(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Categories.Where(w => w.ParentCategoryId == id).ToListAsync();
            }
        }
        public async Task<Category> GetCategoryById(int id)
        {
            using(var db=new DataContext())
            {
                return await db.Categories.FindAsync(id);
            }
        }
        public async Task<Category> CreateCategory(Category category)
        {
            using (var db = new DataContext())
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return category;
            }
        }
        public async Task<Category> UpdateCategory(Category category)
        {
            using(var db=new DataContext())
            {
                db.Categories.Update(category);
                await db.SaveChangesAsync();
                return category;
            }
        }
        public async Task DeleteCategory(int id)
        {
            using (var db = new DataContext())
            {
                var deletecategory = await GetCategoryById(id);
                db.Categories.Remove(deletecategory);
                await db.SaveChangesAsync();
            }
        }

        // Category Details
        public async Task<List<CategoryDetail>> GetAllCategoryDetails()
        {
            using (var db = new DataContext())
            {
                return await db.CategoryDetails.ToListAsync();
            }
        }
        public async Task<List<CategoryDetail>> GetAllCategoryDetailsByCategoryId(int categoryId)
        {
            using (var db = new DataContext())
            {
                return await db.CategoryDetails.Where(w=>w.CategoryId==categoryId).ToListAsync();
            }
        }
        public async Task<CategoryDetail> GetCategoryDetailById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.CategoryDetails.FindAsync(id);
            }
        }
        public async Task<CategoryDetail> CreateCategoryDetail(CategoryDetail categoryDetail)
        {
            using (var db = new DataContext())
            {
                db.CategoryDetails.Add(categoryDetail);
                await db.SaveChangesAsync();
                return categoryDetail;
            }
        }
        public async Task<CategoryDetail> UpdateCategoryDetail(CategoryDetail categoryDetail)
        {
            using (var db = new DataContext())
            {
                db.CategoryDetails.Update(categoryDetail);
                await db.SaveChangesAsync();
                return categoryDetail;
            }
        }
        public async Task DeleteCategoryDetail(int id)
        {
            using (var db = new DataContext())
            {
                var deletecategorydetails = await GetCategoryDetailById(id);
                db.CategoryDetails.Remove(deletecategorydetails);
                await db.SaveChangesAsync();
            }
        }
    }
}
