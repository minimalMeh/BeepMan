using System;
using BeepMan.Model;
using BeepMan.Api.Interfaces;
using BeepMan.Api.ViewModels;
using System.Threading.Tasks;

namespace BeepMan.Api
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customers;
        private readonly IRepository<Product> _products;
        private readonly IUnitOfWorkFactory _unitOfWork;

        public CustomerService(IRepository<Customer> customers, IRepository<Product> products, IUnitOfWorkFactory unitOfWork)
        {
            this._customers = customers;
            this._products = products;
            this._unitOfWork = unitOfWork;
        }

        public Task<bool> CreateCustomer(CustomerViewModel customer)
        {
            var newCustomer  = new Customer()
            {
                Id = Guid.NewGuid(),
                Name = customer.Name,
                Phone = customer.Phone,
                SelectedProduct = this._products.Get(customer.ProductId)
            };
            this._customers.Create(newCustomer);
            return this._unitOfWork.CommitAsync();
        }
    }
}
