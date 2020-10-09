using System;
using System.Linq;
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
        private readonly IAuthService _authService;

        public UsersController(IUserService userService, IAuthService authService)
        {
            this._userService = userService;
            this._authService = authService;
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

#if DEBUG
        [HttpGet("admin/g")]
        public async Task<IActionResult> GenerateAdmin()
        {
            if (this._userService.GetAllUsers().FirstOrDefault( i => i.UserName == "admin") != null)
            {
                return Ok();
            }
            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = "admin@admin.admin"
            };

            var res = await this._authService.RegisterAsync(user, "password");
            if (res)
            {
                await this._authService.AddRoleAsync(user.Id, "Administrator");
                return Ok();
            }

            return BadRequest();
        }
#endif
    }
}
