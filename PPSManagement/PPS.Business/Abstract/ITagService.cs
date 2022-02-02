using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface ITagService
    {
        Task<List<Tag>> GetAllTags();
        Task<Tag> GetTagById(int id);
        Task<Tag> GetTagByTagName(string tagName);
        Task<Tag> CreateTag(Tag tag);
        Task<Tag> UpdateTag(Tag tag);
        Task DeleteTag(int id);

        //product tag mapping
        Task<List<ProductTagMapping>> GetAllProductTagMapping();
        Task<ProductTagMapping> GetProductTagMappingById(int id);
        Task<List<ProductTagMapping>> GetAllProductTagMappingByTagId(int tagId);
        Task<List<ProductTagMapping>> GetAllProductTagMappingByProductId(int productId);
        Task<ProductTagMapping> CreateProductTagMapping(ProductTagMapping productTagMapping);
        Task<ProductTagMapping> UpdateProductTagMapping(ProductTagMapping productTagMapping);
        Task DeleteProductTagMapping(int id);
    }
}
