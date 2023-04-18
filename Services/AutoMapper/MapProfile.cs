using AutoMapper;
using Dtos;
using Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CustomerAddDto>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
            CreateMap<List<Customer>, CustomerListDto>().ReverseMap();
            CreateMap<List<Address>, AddressListDto>().ForMember(x=>x.Addresses,o=>o.MapFrom(s=>s.ToList()));
            CreateMap<Address, AddressAddDto>().ReverseMap();
            //CreateMap<IQueryable<Customer>, CustomerListDto>().ReverseMap();
        }
    }
}
