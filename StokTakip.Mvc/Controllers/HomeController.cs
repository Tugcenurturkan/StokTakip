using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StokTakip.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IProductActivitiesService _productActivitiesService;
        public HomeController(IProductActivitiesService productActivitiesService)
        {
            _productActivitiesService = productActivitiesService;
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> StockActivityGraphic()
        {
            var model = await _productActivitiesService.GetAllProductsInStockGraphic();
            return Json(model);
        }

        [HttpGet]
        public async Task<IActionResult> StockActivityTakeOutGraphic()
        {
            var model = await _productActivitiesService.GetAllTakeOutProductsInStockGraphic();
            return Json(model);
        }
    }
}
