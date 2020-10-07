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
        Product CreateProduct(ProductViewModel product);

        void RemoveProduct(ProductViewModel product);

        IList<Customer> GetProductCustomers(Guid productId);
    }
}
