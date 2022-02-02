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
    public class UsersController : ControllerBase
    {
        protected IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();
            if (users.Count()>0)
            {
                return Ok(users);
            }
            return NoContent();
        }

        
    }
}
