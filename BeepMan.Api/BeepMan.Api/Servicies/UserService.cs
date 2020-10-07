using BeepMan.Api.Interfaces;
using BeepMan.Api.Servicies;
using BeepMan.Api.ViewModels;
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
        private readonly IRepository<Customer> _customers;
        private readonly IRepository<Product> _products;
        private readonly IUnitOfWorkFactory _unitOfWork;

        public UserService(IRepository<User> users, IRepository<Customer> customers,
            IRepository<Product> products, IUnitOfWorkFactory unitOfWork)
        {
            this._users = users;
            this._customers = customers;
            this._products = products;
            this._unitOfWork = unitOfWork;
        }

        public Task<bool> CreateProduct(ProductViewModel product)
        {
            var newProduct = new Product()
            {
                Id = Guid.NewGuid(),
                Brand = product.Brand,
                Model = product.Model,
                Link = product.Link,
                User = _users.Get(product.OwnerId),
                Images = product.Images
            };
            this._products.Create(newProduct);
            return this._unitOfWork.CommitAsync();
        }

        public IList<Customer> GetProductCustomers(Guid productId)
        {
            //TODO: check if needs to change to IQueryable<TEntity>
            return _customers.GetAll().Where(i => i.SelectedProduct.Id == productId).ToList();
        }

        public Task<bool> RemoveProduct(Guid id)
        {
            this._products.Delete(id);
            return this._unitOfWork.CommitAsync();
        }
    }
}
