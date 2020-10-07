using BeepMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeepMan.Api
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Create(Product item)
        {
            _context.Products.Add(item);
        }

        public void Delete(Guid id)
        {
            var product = this.Get(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }

        public Product Get(Guid id)
        {
            return this._context.Products.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return this._context.Products;
        }

        public void Update(Product item)
        {
            var exItem = this.Get(item.Id);
            if (!item.Equals(exItem))
            {
                this._context.Products.Update(exItem);
            }
        }
    }
}
