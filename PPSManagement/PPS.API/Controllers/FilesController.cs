using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class FilesController : ControllerBase
    {
        protected IFileService _fileservice;
        public FilesController(IFileService fileservice)
        {
            _fileservice = fileservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var files = await _fileservice.GetAllFile();
            if (files.Count()>0)
            {
                return Ok(files);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var files = await _fileservice.GetFileById(id);
            if (files!=null)
            {
                return Ok(files);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> FileByCategory(int id)
        {
            var files = await _fileservice.GetFileByCategoryId(id);
            if (files != null)
            {
                return Ok(files);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> FileByBrand(int id)
        {
            var files = await _fileservice.GetFileByBrandId(id);
            if (files != null)
            {
                return Ok(files);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> FileByProduct(int id)
        {
            var files = await _fileservice.GetFileByProductId(id);
            if (files != null)
            {
                return Ok(files);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] File file)
        {
            var createfile = await _fileservice.CreateFile(file);
            return CreatedAtAction("Get", new { id = createfile.CategoryId }, createfile);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] File file)
        {
            if (await _fileservice.GetFileById(file.FileId) != null)
            {
                return Ok(await _fileservice.UpdateFile(file));
            }
            return NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _fileservice.GetFileById(id) != null)
            {
                await _fileservice.DeleteFile(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
