﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class StockActivities : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}