using Dtos;
using Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface ICustomerDal : IGenericDal<Customer>
    {
        Task<List<Customer>> GetCustomerAsync();
        Task<CustomerListDto> CustomerListAsync();
    }
}
