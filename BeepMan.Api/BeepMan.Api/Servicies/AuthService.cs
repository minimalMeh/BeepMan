using BeepMan.Api.Interfaces;
using BeepMan.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Servicies
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public async Task<bool> TryLoginAsync(string email, string password)
        {
            return true;
        }

        public Task<bool> AddRoleAsync(Guid userId, string role)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasRole(Guid userId, string role)
        {
            throw new NotImplementedException();
        }

    }
}
