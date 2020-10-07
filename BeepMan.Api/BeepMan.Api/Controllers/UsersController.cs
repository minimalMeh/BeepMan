using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeepMan.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeepMan.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string userName)
        {
            var result = await this._userService.CreateUserAsync(userName);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
