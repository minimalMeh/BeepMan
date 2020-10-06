using BeepMan.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Servicies
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(Customer item)
        {
            _context.Customers.Add(item);
        }

        public void Delete(Guid id)
        {
            var customer = this.Get(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
        }

        public Customer Get(Guid id)
        {
            return this._context.Customers.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return this._context.Customers;
        }

        public void Update(Customer item)
        {
            var exItem = this.Get(item.Id);
            if(!item.Equals(exItem))
            {
                this._context.Customers.Update(exItem);
            }
        }
    }
}
