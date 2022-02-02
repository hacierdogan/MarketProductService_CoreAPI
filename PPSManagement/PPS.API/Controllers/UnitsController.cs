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
    public class UnitsController : ControllerBase
    {
        private IUnitService _unitservice;

        public UnitsController(IUnitService unitservice)
        {
            _unitservice = unitservice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var units= await _unitservice.GetAllUnits();
            if (units.Count()>0)
            {
                return Ok(units);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var unit = await _unitservice.GetUnitById(id);
            if (unit!=null)
            {
                return Ok(unit);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Unit unit)
        {
           var createdunit= await _unitservice.CreateUnit(unit);
            return CreatedAtAction("Get", new { id = createdunit.UnitId }, createdunit);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Unit unit)
        {
            if (await _unitservice.GetUnitById(unit.UnitId)!=null)
            {
                return Ok(await _unitservice.UpdateUnit(unit));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _unitservice.GetUnitById(id) != null)
            {
                await _unitservice.DeleteUnit(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
