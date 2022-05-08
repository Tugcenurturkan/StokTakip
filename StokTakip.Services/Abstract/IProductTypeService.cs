using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using StokTakip.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services.Abstract
{
    public interface IProductTypeService
    {
        //Task<IDataResult<ProductActivitiesDto>> GetById(Guid productDefinitionId);
        //Task<IDataResult<ProductActivitiesListDto>> GetAll();
        Task<IDataResult<ProductTypeListDto>> GetAllProductType();
        //Task<IDataResult<ProductActivitiesDto>> Add(ProductActivitiesAddDto productDefinitionAddDto);
        //Task<IDataResult<ProductActivitiesDto>> Update(ProductActivitiesUpdateDto productDefinitionUpdateDto);
        //Task<IDataResult<ProductActivitiesDto>> Delete(Guid productDefinitionId);
        Task<IDataResult<ProductTypeDto>> AddProductType(ProductTypeAddDto productTypeAddDto);
        Task<IDataResult<ProductTypeDto>> DeleteProductType(Guid productTypeId);
        Task<IDataResult<ProductTypeDto>> GetByIdProductType(Guid productTypeId);
        Task<IDataResult<ProductTypeDto>> UpdateProductType(ProductTypeUpdateDto productTypeUpdateDto);
        Task<IDataResult<ProductTypeUpdateDto>> GetProductTypeUpdateDto(Guid productTypeId);
        //Task<IDataResult<ProductActivitiesUpdateDto>> GetProductDefinitionUpdateDto(Guid productDefinitionId);
    }
}
