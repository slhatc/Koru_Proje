using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Concrete.EntityFramework.Context;
using Repositories.Concrete.EntityFramework.Repositories;
using Repositories.Interface;
using Services.Concrete;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IoCContainer
{
    public static class IoCExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbContext, KoruProjeContext>();
            services.AddScoped(typeof(IGenericDal<>), typeof(EfGenericRepository<>));

            services.AddScoped<ICustomerService, CustomerManager>();
            services.AddScoped<IAddressService, AddressManager>();


            services.AddScoped<ICustomerDal, EfCustomerRepository>();
            services.AddScoped<IAddressDal, EfAddressRepository>();

           

      

        }
    }
}
