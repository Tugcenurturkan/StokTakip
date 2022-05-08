using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakip.Entities.Dtos;

namespace StokTakip.Mvc.Models
{
    public class ProductTypeUpdateAjaxViewModel
    {
        public ProductTypeUpdateDto ProductTypeUpdateDto { get; set; }
        public string ProductTypeUpdatePartial { get; set; }
        public ProductTypeDto ProductTypeDto { get; set; }
    }
}
