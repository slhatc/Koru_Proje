using Dtos;
using Microsoft.EntityFrameworkCore;
using Models.Concrete;
using Repositories.Concrete.EntityFramework.Context;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EntityFramework.Repositories
{
    public class EfCustomerRepository : EfGenericRepository<Customer>, ICustomerDal
    {
        private readonly KoruProjeContext _context;
        public EfCustomerRepository(KoruProjeContext context) : base(context)
        {
            _context= context;
        }
    
        public async  Task<List<Customer>> GetCustomerAsync()
        {
            return await _context.Customers
                .Include(p => p.Address)
                .ToListAsync();
        }

        public async Task<CustomerListDto> CustomerListAsync()
        {
            var response=new CustomerListDto();

            response.Customers  =await _context.Customers
               .Include(p => p.Address).ToListAsync();
               
            return response;

               
        }
    }
}
