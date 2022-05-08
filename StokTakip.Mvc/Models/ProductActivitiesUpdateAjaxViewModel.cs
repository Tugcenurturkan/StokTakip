using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakip.Entities.Dtos;

namespace StokTakip.Mvc.Models
{
    public class ProductActivitiesUpdateAjaxViewModel
    {
        public ProductActivitiesUpdateDto ProductActivitiesUpdateDto { get; set; }
        public string ProductActivitiesUpdatePartial { get; set; }
        public ProductActivitiesDto ProductActivitiesDto { get; set; }
    }
}
