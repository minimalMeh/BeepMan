using BeepMan.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IAuthService
    {
        Task<bool> TryLoginAsync(string email, string password);

        Task<bool> AddRoleAsync(Guid userId, string role);

        Task<bool> HasRole(Guid userId, string role);

        Task<bool> RegisterAsync(User user, string password);
    }
}
