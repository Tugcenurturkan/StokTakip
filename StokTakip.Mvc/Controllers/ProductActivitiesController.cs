using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class ProductActivitiesController : Controller
    {
        public IActionResult ProductAddActivities()
        {
            return View();
        }
        public IActionResult ProductTakeOutActivities()
        {
            return View();
        }
    }
}
