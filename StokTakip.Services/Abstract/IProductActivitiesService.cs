﻿using StokTakip.Entities.Dtos;
using StokTakip.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services.Abstract
{
    public interface IProductActivitiesService
    {
        Task<IDataResult<ProductActivitiesDto>> GetById(Guid productDefinitionId);
        Task<IDataResult<ProductActivitiesListDto>> GetAllEntryActivities(DateTime? date);
        Task<IDataResult<ProductActivitiesListDto>> GetAllTakeOffActivities(DateTime? date);
        Task<IDataResult<ProductActivitiesDto>> Add(ProductActivitiesAddDto productDefinitionAddDto);
        Task<IDataResult<ProductActivitiesDto>> Update(ProductActivitiesUpdateDto productDefinitionUpdateDto);
        Task<IDataResult<ProductActivitiesDto>> Delete(Guid productDefinitionId);
        Task<IDataResult<ProductActivitiesUpdateDto>> GetProductActivityUpdateDto(Guid productDefinitionId);
        Task<List<StockActivitiesListDto>> GetAllProductsInStock();
        Task<List<StockGraphDto>> GetAllProductsInStockGraphic();
        Task<List<StockGraphDto>> GetAllTakeOutProductsInStockGraphic();


    }
}
