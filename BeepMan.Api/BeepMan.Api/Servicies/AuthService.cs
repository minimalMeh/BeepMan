using BeepMan.Api.Interfaces;
using BeepMan.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.Core;
using System.Threading.Tasks;

namespace BeepMan.Api.Servicies
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AuthService(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<bool> RegisterAsync(User user, string password)
        {
            var passwordHash = CryptoService.CalculateHash(password);
            user.PasswordHash = passwordHash;
            var result = await _userManager.CreateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> TryLoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new ObjectNotFoundException($"User with email: {email} is not found.");
            }

            if (user.PasswordHash == CryptoService.CalculateHash(email))
            {
                return true;
            }
            else
            {
                throw new UnauthorizedAccessException("Password is incorrect.");
            }
        }

        public async Task<bool> AddRoleAsync(Guid userId, string role)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                throw new ObjectNotFoundException($"User with id: {userId} is not found.");
            }

            if (!(await _roleManager.RoleExistsAsync(role)))
            {
                var newRole = new IdentityRole<Guid>()
                {
                    Name = role
                };

                var res = await _roleManager.CreateAsync(newRole);

                if (!res.Succeeded)
                {
                    return false;
                }
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            return result.Succeeded;
        }

        public async Task<bool> HasRole(Guid userId, string role)
        {
            return await _userManager.IsInRoleAsync(await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId), role);
        }

#if DEBUG
        public async void GenerateHeadAdminCreds()
        {
            var email = "admin@admin.admin";
            if (await _userManager.FindByEmailAsync(email) != null)
                return;

            var user = new User()
            {
                Id = Guid.NewGuid(),
                UserName = "admin",
                Email = "admin@admin.admin"
            };
            await RegisterAsync(user, CryptoService.CalculateHash("password"));
            await AddRoleAsync(user.Id, "Administrator");
        }
#endif
    }
}
