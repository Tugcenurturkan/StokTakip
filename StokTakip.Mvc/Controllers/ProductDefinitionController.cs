using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class ProductDefinitionController : Controller
    {
        public IActionResult ProductDefinition()
        {
            return View();
        }
        public IActionResult ProductTypeDefinition()
        {
            return View();
        }
    }
}
