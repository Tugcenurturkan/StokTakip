using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StokTakip.Entities.Dtos;

namespace StokTakip.Mvc.Models
{
    public class ProductActivitiesAddAjaxViewModel
    {
        public ProductActivitiesAddDto ProductActivitiesAddDto { get; set; }
        public string ProductActivitiesAddPartial { get; set; }
        public ProductActivitiesDto ProductActivitiesDto { get; set; }
    }
}
