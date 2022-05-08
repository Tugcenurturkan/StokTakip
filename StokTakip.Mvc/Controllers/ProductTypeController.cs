using Microsoft.AspNetCore.Mvc;
using StokTakip.Entities.Dtos;
using StokTakip.Mvc.Models;
using StokTakip.Services.Abstract;
using StokTakip.Shared.Utilities.Extensions;
using StokTakip.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StokTakip.Mvc.Controllers
{
    public class ProductTypeController : Controller
    {
        private readonly IProductTypeService _productTypeService;
        public ProductTypeController(IProductTypeService productDefinitionService)
        {
            _productTypeService = productDefinitionService;
        }
        //public async Task<IActionResult> ProductDefinition()
        //{
        //    var result = await _productTypeService.GetAll();
        //    if (result.ResultStatus == ResultStatus.Success)
        //    {
        //        return View(result.Data);
        //    }
        //    return View();
        //}
        public async Task<IActionResult> ProductTypeDefinition()
        {
            var result = await _productTypeService.GetAllProductType();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddProductType()
        {
            return PartialView("_ProductTypeAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> AddProductType(ProductTypeAddDto productTypeAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productTypeService.AddProductType(productTypeAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var productTypeAddAjaxModel = JsonSerializer.Serialize(new ProductTypeAddAjaxViewModel
                    {
                        ProductTypeDto = result.Data,
                        ProductTypeAddPartial = await this.RenderViewToStringAsync("_ProductTypeAddPartial", productTypeAddDto)
                    });
                    return Json(productTypeAddAjaxModel);
                }
            }
            var productTypeAddAjaxErrorModel = JsonSerializer.Serialize(new ProductTypeAddAjaxViewModel
            {
                ProductTypeAddPartial = await this.RenderViewToStringAsync("_ProductTypeAddPartial", productTypeAddDto)
            });
            return Json(productTypeAddAjaxErrorModel);

        }
        //[HttpGet]
        //public IActionResult AddProductDefinition()
        //{
        //    return PartialView("_ProductDefinitionAddPartial");
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddProductDefinition(ProductDefinitionAddDto productDefinitonAddDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _productDefinitionService.Add(productDefinitonAddDto);
        //        if (result.ResultStatus == ResultStatus.Success)
        //        {
        //            var productDefinitionAddAjaxModel = JsonSerializer.Serialize(new ProductDefinitionAddAjaxViewModel
        //            {
        //                ProductDefinitionDto = result.Data,
        //                ProductDefinitionAddPartial = await this.RenderViewToStringAsync("_ProductDefinitionAddPartial", productDefinitonAddDto)
        //            });
        //            return Json(productDefinitionAddAjaxModel);
        //        }
        //    }
        //    var productDefinitionAddAjaxErrorModel = JsonSerializer.Serialize(new ProductDefinitionAddAjaxViewModel
        //    {
        //        ProductDefinitionAddPartial = await this.RenderViewToStringAsync("_ProductDefinitionAddPartial", productDefinitonAddDto)
        //    });
        //    return Json(productDefinitionAddAjaxErrorModel);

        //}
        [HttpGet]
        public async Task<IActionResult> UpdateProductType(Guid productTypeId)
        {
            var result = await _productTypeService.GetProductTypeUpdateDto(productTypeId);
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_ProductTypeUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductType(ProductTypeUpdateDto productTypeUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productTypeService.UpdateProductType(productTypeUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var productTypeUpdateAjaxModel = JsonSerializer.Serialize(new ProductTypeUpdateAjaxViewModel
                    {
                        ProductTypeDto = result.Data,
                        ProductTypeUpdatePartial = await this.RenderViewToStringAsync("_ProductTypeUpdatePartial", productTypeUpdateDto)
                    });
                    return Json(productTypeUpdateAjaxModel);
                }
            }
            var productTypeUpdateAjaxErrorModel = JsonSerializer.Serialize(new ProductTypeUpdateAjaxViewModel
            {
                ProductTypeUpdatePartial = await this.RenderViewToStringAsync("_ProductTypeUpdatePartial", productTypeUpdateDto)
            });
            return Json(productTypeUpdateAjaxErrorModel);

        }

        public async Task<JsonResult> GetAllProductTypes()
        {
            var result = await _productTypeService.GetAllProductType();
            var productTypes = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(productTypes);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteProductType(Guid productTypeId)
        {
            var result = await _productTypeService.DeleteProductType(productTypeId);
            var deletedProductType = JsonSerializer.Serialize(result.Data);
            return Json(deletedProductType);
        }
    }
}
