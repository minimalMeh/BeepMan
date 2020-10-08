using BeepMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeepMan.Api
{
    public class UserRepository : IRepository<User>
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
        }

        public void Delete(Guid id)
        {
            var user = this.Get(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public User Get(Guid id)
        {
            return (this._context.Users as IEnumerable<User>).FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return (this._context.Users as IEnumerable<User>);
        }

        public void Update(User item)
        {
            var exItem = this.Get(item.Id);
            if (!item.Equals(exItem))
            {
                this._context.Users.Update(exItem);
            }
        }
    }
}
