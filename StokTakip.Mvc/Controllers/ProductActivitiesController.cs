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
    public class ProductActivitiesController : Controller
    {
        private readonly IProductActivitiesService _productActivitiesService;
        private readonly IProductTypeService _productTypeService;
        public ProductActivitiesController(IProductActivitiesService productActivitiesService, IProductTypeService productTypeService)
        {
            _productActivitiesService = productActivitiesService;
            _productTypeService = productTypeService;
        }
        public async Task<IActionResult> ProductEntryActivities()
        {
            var result = await _productActivitiesService.GetAllEntryActivities();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        public async Task<IActionResult> ProductTakeOutActivities()
        {
            var result = await _productActivitiesService.GetAllTakeOffActivities();
            if (result.ResultStatus == ResultStatus.Success)
            {
                return View(result.Data);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddProductEntry()
        {
            return PartialView("_ProductEntryActivitiesAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> AddProductEntry(ProductActivitiesAddDto productActivitiesAddDto)
        {
            productActivitiesAddDto.ActivityType = 1;
            var productType = _productTypeService.GetByIdProductType(productActivitiesAddDto.ProductTypeId);
            if (ModelState.IsValid)
            {
                var result = await _productActivitiesService.Add(productActivitiesAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    result.Data.ProductActivity.ProductType = productType.Result.Data.ProductType;
                    var productEntryActivitiesAddAjaxModel = JsonSerializer.Serialize(new ProductActivitiesAddAjaxViewModel
                    {
                        ProductActivitiesDto = result.Data,
                        ProductActivitiesAddPartial = await this.RenderViewToStringAsync("_ProductEntryActivitiesAddPartial", productActivitiesAddDto)
                    });
                    return Json(productEntryActivitiesAddAjaxModel);
                }
            }
            var productEntryActivitiesAddAjaxErrorModel = JsonSerializer.Serialize(new ProductActivitiesAddAjaxViewModel
            {
                ProductActivitiesAddPartial = await this.RenderViewToStringAsync("_ProductEntryActivitiesAddPartial", productActivitiesAddDto)
            });
            return Json(productEntryActivitiesAddAjaxErrorModel);

        }
        [HttpGet]
        public IActionResult AddProductTakeOff()
        {
            return PartialView("_ProductTakeOffActivitiesAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> AddProductTakeOff(ProductActivitiesAddDto productActivitiesAddDto)
        {
            productActivitiesAddDto.ActivityType = 2;
            var productType = _productTypeService.GetByIdProductType(productActivitiesAddDto.ProductTypeId);
            if (ModelState.IsValid)
            {
                var result = await _productActivitiesService.Add(productActivitiesAddDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    result.Data.ProductActivity.ProductType = productType.Result.Data.ProductType;
                    var productEntryActivitiesAddAjaxModel = JsonSerializer.Serialize(new ProductActivitiesAddAjaxViewModel
                    {
                        ProductActivitiesDto = result.Data,
                        ProductActivitiesAddPartial = await this.RenderViewToStringAsync("_ProductTakeOffActivitiesAddPartial", productActivitiesAddDto)
                    });
                    return Json(productEntryActivitiesAddAjaxModel);
                }
            }
            var productEntryActivitiesAddAjaxErrorModel = JsonSerializer.Serialize(new ProductActivitiesAddAjaxViewModel
            {
                ProductActivitiesAddPartial = await this.RenderViewToStringAsync("_ProductTakeOffActivitiesAddPartial", productActivitiesAddDto)
            });
            return Json(productEntryActivitiesAddAjaxErrorModel);

        }
        [HttpGet]
        public async Task<IActionResult> UpdateProductEntry(Guid productEntryId)
        {
            var result = await _productActivitiesService.GetProductActivityUpdateDto(productEntryId);
            var productType = _productTypeService.GetByIdProductType(result.Data.ProductTypeId);
            result.Data.ProductType = productType.Result.Data.ProductType;
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_ProductEntryActivitiesUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductEntry(ProductActivitiesUpdateDto productActivitiesUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productActivitiesService.Update(productActivitiesUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var productActivitiesUpdateAjaxModel = JsonSerializer.Serialize(new ProductActivitiesUpdateAjaxViewModel
                    {
                        ProductActivitiesDto = result.Data,
                        ProductActivitiesUpdatePartial = await this.RenderViewToStringAsync("_ProductEntryActivitiesUpdatePartial", productActivitiesUpdateDto)
                    });
                    return Json(productActivitiesUpdateAjaxModel);
                }
            }
            var productActivitiesUpdateAjaxErrorModel = JsonSerializer.Serialize(new ProductActivitiesUpdateAjaxViewModel
            {
                ProductActivitiesUpdatePartial = await this.RenderViewToStringAsync("_ProductEntryActivitiesUpdatePartial", productActivitiesUpdateDto)
            });
            return Json(productActivitiesUpdateAjaxErrorModel);

        }
        [HttpGet]
        public async Task<IActionResult> UpdateProductTakeOff(Guid productTakeOffId)
        {
            var result = await _productActivitiesService.GetProductActivityUpdateDto(productTakeOffId);
            var productType = _productTypeService.GetByIdProductType(result.Data.ProductTypeId);
            result.Data.ProductType = productType.Result.Data.ProductType;
            if (result.ResultStatus == ResultStatus.Success)
            {
                return PartialView("_ProductTakeOffActivitiesUpdatePartial", result.Data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductTakeOff(ProductActivitiesUpdateDto productActivitiesUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _productActivitiesService.Update(productActivitiesUpdateDto);
                if (result.ResultStatus == ResultStatus.Success)
                {
                    var productActivitiesUpdateAjaxModel = JsonSerializer.Serialize(new ProductActivitiesUpdateAjaxViewModel
                    {
                        ProductActivitiesDto = result.Data,
                        ProductActivitiesUpdatePartial = await this.RenderViewToStringAsync("_ProductTakeOffActivitiesUpdatePartial", productActivitiesUpdateDto)
                    });
                    return Json(productActivitiesUpdateAjaxModel);
                }
            }
            var productActivitiesUpdateAjaxErrorModel = JsonSerializer.Serialize(new ProductActivitiesUpdateAjaxViewModel
            {
                ProductActivitiesUpdatePartial = await this.RenderViewToStringAsync("_ProductTakeOffActivitiesUpdatePartial", productActivitiesUpdateDto)
            });
            return Json(productActivitiesUpdateAjaxErrorModel);

        }
        public async Task<JsonResult> GetAllProductEntryActivities()
        {
            var result = await _productActivitiesService.GetAllEntryActivities();
            var entryActivities = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(entryActivities);
        }
        public async Task<JsonResult> GetAllProductTakeOffActivities()
        {
            var result = await _productActivitiesService.GetAllTakeOffActivities();
            var takeOffActivities = JsonSerializer.Serialize(result.Data, new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            });
            return Json(takeOffActivities);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteProductEntryActivities(Guid productEntryId)
        {
            var result = await _productActivitiesService.Delete(productEntryId);
            var deletedEntryActivities = JsonSerializer.Serialize(result.Data);
            return Json(deletedEntryActivities);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteProductTakeOffActivities(Guid productTakeOffId)
        {
            var result = await _productActivitiesService.Delete(productTakeOffId);
            var deletedTakeOffActivities = JsonSerializer.Serialize(result.Data);
            return Json(deletedTakeOffActivities);
        }
    }
}
