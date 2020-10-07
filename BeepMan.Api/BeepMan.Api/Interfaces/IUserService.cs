using BeepMan.Api.ViewModels;
using BeepMan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateProduct(ProductViewModel product);

        Task<bool> RemoveProduct(Guid id);

        IList<Customer> GetProductCustomers(Guid productId);
    }
}
