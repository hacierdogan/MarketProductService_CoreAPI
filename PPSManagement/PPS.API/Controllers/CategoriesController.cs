using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPS.API.Models;
using PPS.Business.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using static PPS.API.Models.CategoryModel;
using File = PPS.Entities.File;

namespace PPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        protected ICategoryService _categoryService;
        protected IProductService _productService;
        protected IFileService _fileservice;
        public CategoriesController(
            ICategoryService categoryService,
            IProductService productService,
            IFileService fileservice)
        {
            _categoryService = categoryService;
            _productService = productService;
            _fileservice = fileservice;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allcategories = await _categoryService.GetAllCategories();
            List<CategoryModel> categoryModel = new List<CategoryModel>();

            foreach (var item in allcategories)
            {
                CategoryModel categoritem = new CategoryModel();
                categoritem.CategoryId = item.CategoryId;
                categoritem.Name = item.Name;
                categoritem.Description = item.Description;
                categoritem.Status = item.Status;

                var subcategories = await _categoryService.GetAllCategoriesByParentId(item.CategoryId);
                categoritem.SubCategoryCount = subcategories.Count();

                var product = await _productService.GetAllProductByCategoryId(item.CategoryId);
                categoritem.ProductCount = product.Count();

                var parent = await _categoryService.GetCategoryById(item.ParentCategoryId);
                if (parent == null)
                {
                    categoritem.ParentCategoryId = 0;
                    categoritem.ParentCategoryName = "-";
                }
                else
                {
                    categoritem.ParentCategoryId = parent.CategoryId;
                    categoritem.ParentCategoryName = parent.Name;
                }

                var files = await _fileservice.GetFileByCategoryId(item.CategoryId);
                if (files.Count() == 0)
                {
                    categoritem.ImageUrl = "http://localhost:61261/upload/images/noimage.jpg";//test
                }
                else
                {
                    categoritem.ImageUrl = files.FirstOrDefault().DownloadURLPath;
                }
                categoryModel.Add(categoritem);
            }

            if (categoryModel.Count() > 0)
            {
                return Ok(categoryModel);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            //// category with subcategory
            //CetagoryModel categorymodel = new CetagoryModel();
            //categorymodel.CategoryId = category.CategoryId;
            //categorymodel.Name = category.Name;
            //categorymodel.Description = category.Description;
            //categorymodel.ParentCategoryId = category.ParentCategoryId;
            //categorymodel.Status = category.Status;

            //foreach (var getsubcategory in await _categoryService.GetAllCategoriesByParentId(id))
            //{
            //    SubCategoryModel subcategory = new SubCategoryModel();
            //    subcategory.SubCaregoryId = getsubcategory.CategoryId;
            //    subcategory.SubCaregoryName = getsubcategory.Name;
            //    categorymodel.SubCategories.Add(subcategory);
            //}

            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Post([FromBody] CategoryModel category)
        {
            Category dbcategory = new Category();
            dbcategory.Name = category.Name;
            dbcategory.Description = category.Description;
            dbcategory.Status = category.Status;
            dbcategory.ParentCategoryId = category.ParentCategoryId;

            var createcategory = await _categoryService.CreateCategory(dbcategory);

            if (category.Image != null)
            {
                var extension = Path.GetExtension(category.Image.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload/images/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                category.Image.CopyTo(stream);

                File file = new File();
                file.FileName = category.Image.FileName;
                file.DownloadURLPath = newimagename;
                file.CategoryId = createcategory.CategoryId;
                file.BrandId = 0;
                file.ProductId = 0;

                await _fileservice.CreateFile(file);
            }

            #region upload2

            //[ TOPLANTIDA GORUSULECEK *Ayri fonksiyon olabilir ]

            //var file = Request.Form.Files[0];
            //var folderName = Path.Combine("Resource", "Images");
            //var pathToSave= Path.Combine(Directory.GetCurrentDirectory(), folderName);

            //if (file.Length > 0)
            //{
            //    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //    var fullPath = Path.Combine(pathToSave, fileName);
            //    var dbPath = Path.Combine(folderName, fileName);

            //    using(var stream=new FileStream(fullPath, FileMode.Create))
            //    {
            //        file.CopyTo(stream);
            //    }
            //}

            #endregion

            return CreatedAtAction("Get", new { id = createcategory.CategoryId }, createcategory);
        }

        //[Route("[action]")]
        //[HttpPost, DisableRequestSizeLimit]
        //public IActionResult Upload()
        //{
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);
        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex}");
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CategoryModel category)
        {
            var updatecategory = await _categoryService.GetCategoryById(category.CategoryId);

            if (updatecategory != null)
            {
                updatecategory.Name = category.Name;
                updatecategory.Description = category.Description;
                updatecategory.ParentCategoryId = category.ParentCategoryId;
                updatecategory.Status = category.Status;

                return Ok(await _categoryService.UpdateCategory(updatecategory));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            var subcategory = await _categoryService.GetAllCategoriesByParentId(id);

            var files = await _fileservice.GetFileByCategoryId(id);
            if (category != null)
            {
                if (subcategory.Count == 0)
                {
                    //Delete category
                    foreach (var fileitem in files)
                    {
                        await _fileservice.DeleteFile(fileitem.FileId);
                    }
                    //delete category
                    await _categoryService.DeleteCategory(id);
                    return Ok("Kategori silindi.");
                }
                else
                {
                    return BadRequest("Bu kategori, alt kategori içerdiği için silinemez.");
                }
            }
            return NotFound();
        }
    }
}
