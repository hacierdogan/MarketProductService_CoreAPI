using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPS.Business.Abstract;
using PPS.Business.Concrete;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private ILanguageService _languageservice;

        public LanguagesController(ILanguageService languageService)
        {
            _languageservice = languageService;
        }

        //api/languages
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var languages = await _languageservice.GelAllLanguages();
            if (languages.Count>0)
            {
                return Ok(languages); //200
            }
            return NoContent();
        }

        //api/languages/1
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var language = await _languageservice.GetLanguageById(id);
            if (language!=null)
            {
                return Ok(language);//200
            }
            return NotFound(); //404
        }

        //api/languages/languagebyshortcode/1
        [HttpGet]
        [Route("[action]/{shortcode}")]
        public async Task<IActionResult> LanguageByShortCode(string shortcode)
        {
            var language = await _languageservice.GetLanguageByShortCode(shortcode);
            if (language != null)
            {
                return Ok(language);//200
            }
            return NotFound(); //404
        }

        //api/languages/
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Language language)
        {
            //NOT: [ApiController] oldugu icin modelstate otomatik yapılacak.
            var createdLanguage = await _languageservice.CreateLanguage(language);
            return CreatedAtAction("Get", new { id = createdLanguage.LanguageId }, createdLanguage);
        }

        //api/languages/
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Language language)
        {
            if (await _languageservice.GetLanguageById(language.LanguageId)!=null)
            {
                return Ok(await _languageservice.UpdateLanguage(language));//200
            }
            return NotFound();
        }

        //api/languages/
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _languageservice.GetLanguageById(id) != null)
            {
                await _languageservice.DeleteLanguage(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
