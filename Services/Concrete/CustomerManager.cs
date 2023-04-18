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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;
        private readonly IAddressDal _addressDal;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDal customerDal, IMapper mapper,IAddressDal addressDal)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _addressDal = addressDal;
        }
        public async Task AddAsync(CustomerAddDto customerAddDto)
        {
            var customer = _mapper.Map<CustomerAddDto, Customer>(customerAddDto);
            await _customerDal.AddAsync(customer);

        }

        public async Task DeleteAsync(int CustomerId)
        {
            var result = await _customerDal.FindByIdAsync(CustomerId);
            await _customerDal.RemoveAsync(result);

        }

        public async Task<CustomerListDto> GetAllAsync()
        {
            return await _customerDal.CustomerListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerDal.FindByIdAsync(id);
        }

        public async Task UpdateAsync(CustomerUpdateDto customerUpdateDto)
        {
            var customer = await _customerDal.FindByIdAsync(customerUpdateDto.Id);
            customer = _mapper.Map<CustomerUpdateDto, Customer>(customerUpdateDto,customer);
            await _customerDal.UpdateAsync(customer);
        }
    }
}
