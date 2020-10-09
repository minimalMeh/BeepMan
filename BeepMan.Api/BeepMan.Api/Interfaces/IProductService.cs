using BeepMan.Api.ViewModels;
using BeepMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(ProductViewModel product);

        Task<bool> RemoveProductAsync(Guid id);

        IList<Customer> GetProductCustomers(Guid productId);

        IList<Product> GetAll();
    }
}
