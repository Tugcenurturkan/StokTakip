using AutoMapper;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.AutoMapper.Profiles
{
    public class ProductTypeProfile: Profile
    {
        public ProductTypeProfile()
        {
            CreateMap<ProductTypeAddDto, ProductType>().ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductTypeUpdateDto, ProductType>().ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductType, ProductTypeUpdateDto>();
        }
    }
}
