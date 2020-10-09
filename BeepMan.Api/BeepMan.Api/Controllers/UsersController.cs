using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeepMan.Api.Constants;
using BeepMan.Api.Interfaces;
using BeepMan.Api.ViewModels;
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
        public IList<User> GetAll()
        {
            return this._userService.GetAllUsers();
        }

        [HttpPost("new")]
        public async Task<IActionResult> Create([FromBody] RegistrationViewModel user)
        {
            var newUser = new User()
            {
                Id = Guid.NewGuid(),
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            var result = await this._authService.RegisterAsync(newUser, user.Password);
            if (result)
            {
                await this._authService.AddRoleAsync(newUser.Id, Roles.Client);
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
                await this._authService.AddRoleAsync(user.Id, Roles.Adminitrator);
                return Ok();
            }

            return BadRequest();
        }
#endif
    }
}
