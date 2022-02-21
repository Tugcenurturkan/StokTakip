using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakip.Entities.Dtos;

namespace StokTakip.Mvc.Models
{
    public class RoleUpdateAjaxViewModel
    {
        public RoleUpdateDto RoleUpdateDto { get; set; }
        public string RoleUpdatePartial { get; set; }
        public RoleDto RoleDto { get; set; }
    }
}
