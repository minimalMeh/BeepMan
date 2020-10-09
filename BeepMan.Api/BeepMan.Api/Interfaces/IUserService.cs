using BeepMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IUserService
    {
        IList<User> GetAllUsers();
    }
}
