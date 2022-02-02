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
    public class TagService : ITagService
    {
        protected ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }


        public async Task<List<Tag>> GetAllTags()
        {
            return await _tagRepository.GetAllTags();
        }
        public async Task<Tag> GetTagById(int id)
        {
            return await _tagRepository.GetTagById(id);
        }
        public async Task<Tag> GetTagByTagName(string tagName)
        {
            return await _tagRepository.GetTagByTagName(tagName);
        }
        public async Task<Tag> CreateTag(Tag tag)
        {
            return await _tagRepository.CreateTag(tag);
        }
        public async Task<Tag> UpdateTag(Tag tag)
        {
            return await _tagRepository.UpdateTag(tag);
        }
        public async Task DeleteTag(int id)
        {
            await _tagRepository.DeleteTag(id);
        }

        // Product Tag Mapping
        public async Task<List<ProductTagMapping>> GetAllProductTagMapping()
        {
            return await _tagRepository.GetAllProductTagMapping();
        }
        public async Task<List<ProductTagMapping>> GetAllProductTagMappingByProductId(int productId)
        {
            return await _tagRepository.GetAllProductTagMappingByProductId(productId);
        }
        public async Task<List<ProductTagMapping>> GetAllProductTagMappingByTagId(int tagId)
        {
            return await _tagRepository.GetAllProductTagMappingByTagId(tagId);
        }
        public async Task<ProductTagMapping> UpdateProductTagMapping(ProductTagMapping productTagMapping)
        {
            return await _tagRepository.UpdateProductTagMapping(productTagMapping);
        }
        public async Task<ProductTagMapping> GetProductTagMappingById(int id)
        {
            return await _tagRepository.GetProductTagMappingById(id);
        }
        public async Task<ProductTagMapping> CreateProductTagMapping(ProductTagMapping productTagMapping)
        {
            return await _tagRepository.CreateProductTagMapping(productTagMapping);
        }
        public async Task DeleteProductTagMapping(int id)
        {
            await _tagRepository.DeleteProductTagMapping(id);
        }

    }
}
