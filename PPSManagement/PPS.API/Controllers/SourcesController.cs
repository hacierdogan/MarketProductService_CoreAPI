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
    public class SourcesController : ControllerBase
    {
        protected ISourceService _sourceService;
        public SourcesController(ISourceService sourceService)
        {
            _sourceService = sourceService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sources = await _sourceService.GetAllSource();
            if (sources.Count()>0)
            {
                return Ok(sources);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var sources = await _sourceService.GetSourcebyId(id);
            if (sources != null)
            {
                return Ok(sources);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Source source)
        {
            var createsource = await _sourceService.CreateSource(source);
            return CreatedAtAction("Get", new { id = createsource.SourceId }, createsource);
        }

        [HttpPut]
        public async Task<IActionResult>Put([FromBody] Source source)
        {
            if (await _sourceService.GetSourcebyId(source.SourceId)!=null)
            {
                return Ok(await _sourceService.UpdateSource(source));
            }
            return NotFound();
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _sourceService.GetSourcebyId(id) != null)
            {
                await _sourceService.DeleteSource(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
