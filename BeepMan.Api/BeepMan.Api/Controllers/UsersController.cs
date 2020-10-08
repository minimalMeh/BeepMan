using System.Threading.Tasks;
using BeepMan.Api.Interfaces;
using BeepMan.Model;
using Microsoft.AspNetCore.Mvc;

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
