using BeepMan.Api.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeepMan.Api.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomer(CustomerViewModel customer);
    }
}
