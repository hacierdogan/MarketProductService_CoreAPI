using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class ProductService : IProductService
    {
        protected IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _productRepository.GetAllProduct();
        }
        public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            return await _productRepository.GetAllProductByCategoryId(categoryId);
        }
        public async Task<List<Product>> GetAllProductByBrandId(int brandId)
        {
            return await _productRepository.GetAllProductByBrandId(brandId);
        }
        public Task<Product> GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }
        public async Task<Product> CreateProduct(Product product)
        {
            return await _productRepository.CreateProduct(product);
        }
        public Task<Product> UpdateProduct(Product product)
        {
            return _productRepository.UpdateProduct(product);
        }
        public async Task DeleteProduct(int id)
        {
            await _productRepository.DeleteProduct(id);
        }

        // Product Detail
        public async Task<List<ProductDetail>> GetAllProductDetails()
        {
            return await _productRepository.GetAllProductDetails();
        }
        public async Task<List<ProductDetail>> GetAllProductDetailByProductId(int productId)
        {
            return await _productRepository.GetAllProductDetailByProductId(productId);
        }
        public async Task<ProductDetail> GetProductDetailById(int id)
        {
            return await _productRepository.GetProductDetailById(id);
        }
        public async Task<ProductDetail> CreateProductDetail(ProductDetail productDetail)
        {
            return await _productRepository.CreateProductDetail(productDetail);
        }
        public async Task<ProductDetail> UpdateProductDetail(ProductDetail productDetail)
        {
            return await _productRepository.UpdateProductDetail(productDetail);
        }
        public async Task DeleteProductDetail(int id)
        {
            await _productRepository.DeleteProductDetail(id);
        }
    }
}
