using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();
        Task<List<Product>> GetAllProductByCategoryId(int categoryId);
        Task<List<Product>> GetAllProductByBrandId(int brandId);
        Task<Product> GetProductById(int id);
        Task<Product> CreateProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);

        //Product Details
        Task<List<ProductDetail>> GetAllProductDetails();
        Task<List<ProductDetail>> GetAllProductDetailByProductId(int productId);
        Task<ProductDetail> GetProductDetailById(int id);
        Task<ProductDetail> CreateProductDetail(ProductDetail productDetail);
        Task<ProductDetail> UpdateProductDetail(ProductDetail productDetail);
        Task DeleteProductDetail(int id);
    }
}
