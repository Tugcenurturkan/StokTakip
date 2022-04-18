using Microsoft.AspNetCore.Mvc;
using StokTakip.Services.Abstract;
using StokTakip.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class ProductActivitiesController : Controller
    {
        private readonly IProductActivitiesService _productActivitiesService;
        public ProductActivitiesController(IProductActivitiesService productActivitiesService)
        {
            _productActivitiesService = productActivitiesService;
        }
        public async Task<IActionResult> ProductAddActivities()
        {
            var result = await _productActivitiesService.GetAll();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        public async Task<IActionResult> ProductTakeOutActivities()
        {
            var result = await _productActivitiesService.GetAll();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
    }
}
