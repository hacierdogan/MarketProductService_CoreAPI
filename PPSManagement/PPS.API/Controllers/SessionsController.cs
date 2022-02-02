using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPS.Business.Abstract;
using PPS.Business.Concrete;//2 with repo
using PPS.DataAccess.Concrete;//2 with repo
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        SessionService _sessionService = new SessionService(new SessionRepository());

        //protected ISessionService _sessionService;
        //public SessionsController(ISessionService sessionService)
        //{
        //    _sessionService = sessionService;
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allsession= await _sessionService.TGetAll();
            return Ok(allsession);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var allsession = await _sessionService.TGetById(id);
            return Ok(allsession);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Session session)
        {
            var createsession =await _sessionService.TCreate(session);
            return CreatedAtAction("Get", new { id = createsession.SessionId }, createsession);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Session session)
        {
            //var updatesession = await _sessionService.TGetById(session.SessionId);
            //if (updatesession!=null)
            //{
                return Ok(await _sessionService.TUpdate(session));
            //}
            //return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletesession = await _sessionService.TGetById(id);
            if (deletesession != null)
            {
                await _sessionService.TDelete(deletesession.SessionId);
                return Ok("Session silindi.");
            }
            return NotFound();
        }
    }
}
