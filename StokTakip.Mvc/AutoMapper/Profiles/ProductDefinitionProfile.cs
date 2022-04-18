using AutoMapper;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.AutoMapper.Profiles
{
    public class ProductDefinitionProfile : Profile
    {
        public ProductDefinitionProfile()
        {
            CreateMap<ProductDefinitionAddDto, ProductDefinition>().ForMember(dest => dest.CreatedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductDefinitionUpdateDto, ProductDefinition>().ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));
            CreateMap<ProductDefinition, ProductDefinitionUpdateDto>();
        }
    }
}
