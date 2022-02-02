using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPS.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        protected ITagService _tagService;
        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Get()
        {
            var tags = await _tagService.GetAllTags();
            if (tags.Count()>0)
            {
                return Ok(tags);
            }
            return NotFound();
        }
    }
}
