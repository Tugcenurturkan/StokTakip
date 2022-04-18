using Microsoft.AspNetCore.Mvc;
using StokTakip.Services.Abstract;
using StokTakip.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class ProductDefinitionController : Controller
    {
        private readonly IProductDefinitionService _productDefinitionService;
        public ProductDefinitionController(IProductDefinitionService productDefinitionService)
        {
            _productDefinitionService = productDefinitionService;
        }
        public async Task<IActionResult> ProductDefinition()
        {
            var result = await _productDefinitionService.GetAll();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        public async Task<IActionResult> ProductTypeDefinition()
        {
            var result = await _productDefinitionService.GetAllProductType();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
    }
}
