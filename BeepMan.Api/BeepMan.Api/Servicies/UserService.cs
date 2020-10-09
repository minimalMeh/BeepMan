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

        public Task<bool> CreateUserAsync(string userName)
        {
            this._users.Create(new User { Id = Guid.NewGuid(), UserName = userName });
            return this._unitOfWork.CommitAsync();
        }

        public List<User> GetAllUsers()
        {
            return this._users.GetAll().ToList();
        }
    }
}
