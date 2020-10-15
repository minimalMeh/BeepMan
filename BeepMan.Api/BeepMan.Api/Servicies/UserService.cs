using System.Linq;
using BeepMan.Model;
using BeepMan.Api.Interfaces;
using System.Collections.Generic;

namespace BeepMan.Api
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _users;
        private readonly IUnitOfWorkFactory _unitOfWork;

        public UserService(IRepository<User> users, IUnitOfWorkFactory unitOfWork)
        {
            this._users = users;
            this._unitOfWork = unitOfWork;
        }

        public IList<User> GetAllUsers()
        {
            return this._users.GetAll().ToList();
        }
    }
}
