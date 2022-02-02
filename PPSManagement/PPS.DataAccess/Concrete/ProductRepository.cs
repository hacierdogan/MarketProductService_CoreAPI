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
    public class ProductRepository : IProductRepository
    {
        public async Task<List<Product>> GetAllProduct()
        {
            using (var db = new DataContext())
            {
                return await db.Products.ToListAsync();
            }
        }
        public async Task<List<Product>> GetAllProductByCategoryId(int categoryId)
        {
            using (var db = new DataContext())
            {
                return await db.Products.Where(w=>w.CategoryId==categoryId).ToListAsync();
            }
        }
        public async Task<List<Product>> GetAllProductByBrandId(int brandId)
        {
            using(var db=new DataContext())
            {
                return await db.Products.Where(W => W.BrandId == brandId).ToListAsync();
            }
        }
        public async Task<Product> GetProductById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Products.FindAsync(id);
            }
        }
        public async Task<Product> CreateProduct(Product product)
        {
            using (var db = new DataContext())
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return product;
            }
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            using (var db = new DataContext())
            {
                db.Products.Update(product);
                await db.SaveChangesAsync();
                return product;
            }
        }
        public async Task DeleteProduct(int id)
        {
            using (var db = new DataContext())
            {
                var deleteproduct = await GetProductById(id);
                db.Products.Remove(deleteproduct);
                await db.SaveChangesAsync();
            }
        }

        //Product Details
        public async Task<List<ProductDetail>> GetAllProductDetails()
        {
           using(var db=new DataContext())
            {
                return await db.ProductDetails.ToListAsync();
            }
        }
        public async Task<List<ProductDetail>> GetAllProductDetailByProductId(int productId)
        {
            using(var db=new DataContext())
            {
                return await db.ProductDetails.Where(w => w.ProductId == productId).ToListAsync();
            }
        }
        public async Task<ProductDetail> GetProductDetailById(int id)
        {
            using(var db=new DataContext())
            {
                return await db.ProductDetails.FindAsync(id);
            }
        }
        public async Task<ProductDetail> CreateProductDetail(ProductDetail productDetail)
        {
            using(var db=new DataContext())
            {
                db.ProductDetails.Add(productDetail);
                await db.SaveChangesAsync();
                return productDetail;
            }
        }
        public async Task<ProductDetail> UpdateProductDetail(ProductDetail productDetail)
        {
            using(var db=new DataContext())
            {
                db.ProductDetails.Update(productDetail);
                await db.SaveChangesAsync();
                return productDetail;
            }
        }
        public async Task DeleteProductDetail(int id)
        {
            using(var db=new DataContext())
            {
                var deleteproductdetail=await GetProductDetailById(id);
                db.ProductDetails.Remove(deleteproductdetail);
                await db.SaveChangesAsync();
            }
        }
    }
}
