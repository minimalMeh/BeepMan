using BeepMan.Api.Interfaces;
using BeepMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
