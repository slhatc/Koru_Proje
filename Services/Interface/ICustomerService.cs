using Dtos;
using Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface ICustomerService
    {
        Task<CustomerListDto> GetAllAsync();
        Task AddAsync(CustomerAddDto customerAddDto);

        Task UpdateAsync(CustomerUpdateDto customerUpdateDto);
        Task DeleteAsync(int CustomerId);

        Task<Customer> GetByIdAsync(int id);
    }
}
