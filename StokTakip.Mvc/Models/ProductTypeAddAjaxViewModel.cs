using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakip.Entities.Dtos;

namespace StokTakip.Mvc.Models
{
    public class ProductTypeAddAjaxViewModel
    {
        public ProductTypeAddDto ProductTypeAddDto { get; set; }
        public string ProductTypeAddPartial { get; set; }
        public ProductTypeDto ProductTypeDto { get; set; }
    }
}
