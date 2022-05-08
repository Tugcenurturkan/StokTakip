using Microsoft.AspNetCore.Mvc;
using StokTakip.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class StockActivitiesController : Controller
    {
        private readonly IProductActivitiesService _productActivitiesService;
        private readonly IProductTypeService _productTypeService;
        public StockActivitiesController(IProductActivitiesService productActivitiesService, IProductTypeService productTypeService)
        {
            _productActivitiesService = productActivitiesService;
            _productTypeService = productTypeService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
