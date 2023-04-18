using Microsoft.EntityFrameworkCore;
using Models.Concrete;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Concrete.EntityFramework.Repositories
{
    public class EfAddressRepository : EfGenericRepository<Address> , IAddressDal
    {
        public EfAddressRepository(DbContext context) : base(context)
        {

        }

    }
}
