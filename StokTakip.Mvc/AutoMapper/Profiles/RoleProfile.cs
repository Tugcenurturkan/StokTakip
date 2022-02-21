using AutoMapper;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.AutoMapper.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleAddDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
            CreateMap<Role, RoleUpdateDto>();
        }
    }
}
