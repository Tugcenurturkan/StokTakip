using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class UserAccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
