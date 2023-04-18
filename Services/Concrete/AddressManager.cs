using AutoMapper;
using Dtos;
using Models.Concrete;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IMapper _mapper;
        public AddressManager(IAddressDal addressDal, IMapper mapper)
        {
            _addressDal = addressDal;
            _mapper = mapper;
        }
        public async Task<Address> AddAsync(AddressAddDto model)
        {
            var address = _mapper.Map<AddressAddDto, Address>(model);
            if (address != null)
            {
                await _addressDal.AddAsync(address);
            }
            return address;
        }

        public async Task DeleteAsync(int addressId)
        {
            var result = await _addressDal.FindByIdAsync(addressId);
            await _addressDal.RemoveAsync(result);
        }

        public async Task<AddressListDto> GetAllAsync()
        {
            var addresses = _mapper.Map<List<Address>, AddressListDto>(await _addressDal.GetAllAsync());
            return addresses;
        }


    }
}
