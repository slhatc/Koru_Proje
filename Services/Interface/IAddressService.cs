using Dtos;
using Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public  interface IAddressService
    {
        Task<AddressListDto> GetAllAsync();
        Task<Address> AddAsync(AddressAddDto address);
        Task DeleteAsync(int addressId);

    }
}
