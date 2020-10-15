using BeepMan.Model;
using System.Collections.Generic;

namespace BeepMan.Api.Interfaces
{
    public interface IUserService
    {
        IList<User> GetAllUsers();
    }
}
