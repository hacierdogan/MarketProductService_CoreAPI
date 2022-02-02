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
    public class TagRepository : ITagRepository
    {

        public async Task<List<Tag>> GetAllTags()
        {
            using (var db = new DataContext())
            {
                return await db.Tags.ToListAsync();
            }
        }
        public async Task<Tag> GetTagById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Tags.FindAsync(id);
            }
        }
        public async Task<Tag> GetTagByTagName(string tagName)
        {
            using (var db = new DataContext())
            {
                return await db.Tags.FirstOrDefaultAsync(w => w.Title == tagName);
            }
        }
        public async Task<Tag> CreateTag(Tag tag)
        {
            using(var db=new DataContext())
            {
                db.Tags.Add(tag);
                await db.SaveChangesAsync();
                return tag;
            }
        }
        public async Task DeleteTag(int id)
        {
            using(var db=new DataContext())
            {
                var deletetag = await GetTagById(id);
                db.Tags.Remove(deletetag);
                await db.SaveChangesAsync();
            }
        }
        public async Task<Tag> UpdateTag(Tag tag)
        {
            using(var db=new DataContext())
            {
                db.Tags.Update(tag);
                await db.SaveChangesAsync();
                return tag;
            }
        }

        //Product Tag Mapping
        public async Task<List<ProductTagMapping>> GetAllProductTagMapping()
        {
            using (var db = new DataContext())
            {
                return await db.ProductTagMappings.ToListAsync();
            }
        }
        public async Task<ProductTagMapping> GetProductTagMappingById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.ProductTagMappings.FindAsync(id);
            }
        }
        public async Task<List<ProductTagMapping>> GetAllProductTagMappingByProductId(int productId)
        {
            using (var db = new DataContext())
            {
                return await db.ProductTagMappings.Where(w => w.ProductId == productId).ToListAsync();
            }
        }
        public async Task<List<ProductTagMapping>> GetAllProductTagMappingByTagId(int tagId)
        {
            using (var db = new DataContext())
            {
                return await db.ProductTagMappings.Where(w => w.TagId == tagId).ToListAsync();
            }
        }
        public async Task<ProductTagMapping> CreateProductTagMapping(ProductTagMapping productTagMapping)
        {
            using (var db = new DataContext())
            {
                db.ProductTagMappings.Add(productTagMapping);
                await db.SaveChangesAsync();
                return productTagMapping;
            }
        }
        public async Task<ProductTagMapping> UpdateProductTagMapping(ProductTagMapping productTagMapping)
        {
            using (var db = new DataContext())
            {
                db.ProductTagMappings.Update(productTagMapping);
                await db.SaveChangesAsync();
                return productTagMapping;
            }
        }
        public async Task DeleteProductTagMapping(int id)
        {
            using (var db = new DataContext())
            {
                var deteleproducttagmapping = await GetProductTagMappingById(id);
                db.ProductTagMappings.Remove(deteleproducttagmapping);
                await db.SaveChangesAsync();
            }
        }

    }
}
