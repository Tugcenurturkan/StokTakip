using AutoMapper;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.AutoMapper.Profiles
{
    public class ProductActivityProfile : Profile
    {
        public ProductActivityProfile()
        {
            CreateMap<ProductActivitiesAddDto, ProductActivity>().ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductActivitiesUpdateDto, ProductActivity>().ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductActivity, ProductActivitiesUpdateDto>();

            //CreateMap<ProductTypeAddDto, ProductType>().ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            //CreateMap<ProductTypeUpdateDto, ProductType>().ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            //CreateMap<ProductType, ProductTypeUpdateDto>();
        }
    }
}
