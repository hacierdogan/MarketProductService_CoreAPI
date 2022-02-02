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
    public class BrandsController : ControllerBase
    {
        protected IBrandService _brandService;
        protected IFileService _fileservice;
        protected IProductService _productService;
        public BrandsController(
            IBrandService brandService,
            IFileService fileservice,
            IProductService productService
            )
        {
            _brandService = brandService;
            _fileservice = fileservice;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var brands= await _brandService.GetAllBrands();
            List<BrandModel> brandlist = new List<BrandModel>();

            foreach (var branditem in brands)
            {
                BrandModel brand = new BrandModel();
                brand.BrandId = branditem.BrandId;
                brand.Name = branditem.Name;
                brand.Description = branditem.Description;
                brand.Status = branditem.Status;

                var file = await _fileservice.GetFileByBrandId(branditem.BrandId);
                if (file.Count==0)
                {
                    brand.ImageUrl = "http://localhost:61261/upload/images/noimage.jpg";
                }
                else
                {
                    brand.ImageUrl = file.FirstOrDefault().DownloadURLPath;
                }                

                var products = await _productService.GetAllProductByBrandId(branditem.BrandId);
                brand.ProductCount = products.Count();

                brandlist.Add(brand);
            }


            if (brandlist.Count>0)
            {
                return Ok(brandlist);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await _brandService.GetBrandById(id);
            if (brand!=null)
            {
                return Ok(brand);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Brand brand)
        {
            var createdbrand = await _brandService.CreateBrand(brand);
            return CreatedAtAction("Get",new { id=createdbrand.BrandId},createdbrand);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Brand brand)
        {
            if (await _brandService.GetBrandById(brand.BrandId)!=null)
            {
                return Ok(await _brandService.UpdateBrand(brand));
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _brandService.GetBrandById(id) != null)
            {
                await _brandService.DeleteBrand(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
