using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakip.Entities.Dtos;

namespace StokTakip.Mvc.Models
{
    public class RoleAddAjaxViewModel
    {
        public RoleAddDto RoleAddDto { get; set; }
        public string RoleAddPartial { get; set; }
        public RoleDto RoleDto { get; set; }
    }
}
