using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(string userName);
    }
}
