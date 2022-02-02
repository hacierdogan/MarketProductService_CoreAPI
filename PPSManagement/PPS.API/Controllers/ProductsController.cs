using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPS.API.Models;
using PPS.Business.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected IProductService _prosuctService;
        protected IFileService _fileservice;
        public ProductsController(
            IProductService prosuctService,
            IFileService fileservice
            )
        {
            _prosuctService = prosuctService;
            _fileservice = fileservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _prosuctService.GetAllProduct();
            if (products.Count() > 0)
            {
                return Ok(products);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var products = await _prosuctService.GetProductById(id);
            if (products!=null)
            {
                return Ok(products);
            }
            return NoContent();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetProductByFilteringModel(ProductFilteringModel filtermodel)
        {
            var allproducts = await _prosuctService.GetAllProduct();
            if (allproducts.Count()>0)
            {
                foreach (var item in allproducts)
                {
                    if (item.Name != filtermodel.ProductName)
                    {
                        allproducts.Remove(item);
                    }
                }
                return Ok(allproducts);
            }
            return NoContent();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {
            var createproduct = await _prosuctService.CreateProduct(product);
            return CreatedAtAction("Get", new { id = createproduct.ProductId }, createproduct);
        }

        [HttpPut]
        public async Task<IActionResult>Put([FromBody] Product produc)
        {
            if (await _prosuctService.GetProductById(produc.ProductId)!=null)
            {
                return Ok(await _prosuctService.UpdateProduct(produc));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _prosuctService.GetProductById(id) != null)
            {
               await _prosuctService.DeleteProduct(id);
            }
            return NotFound();
        }
    }
}
