using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BeepMan.Model
{
    public class UserValidator<TUser> : IUserValidator<TUser>  where TUser : User
    {
        Task<IdentityResult> IUserValidator<TUser>.ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
