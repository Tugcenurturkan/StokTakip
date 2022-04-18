using StokTakip.Entities.Dtos;
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
        Task<IDataResult<ProductDefinitionDto>> GetById(Guid productDefinitionId);
        Task<IDataResult<ProductDefinitionListDto>> GetAll();
        Task<IDataResult<ProductTypeListDto>> GetAllProductType();
        Task<IResult> Add(ProductDefinitionAddDto productDefinitionAddDto, Guid createdUser);
        Task<IResult> Update(ProductDefinitionUpdateDto productDefinitionUpdateDto, Guid modifiedUser);
        Task<IResult> Delete(Guid productDefinitionId, string modifiedByName);
        Task<IResult> AddProductType(ProductTypeAddDto productTypeAddDto, Guid createdUser);
        Task<IResult> DeleteProductType(Guid productTypeId, string modifiedByName);
        Task<IDataResult<ProductTypeDto>> GetByIdProductType(Guid productTypeId);
        Task<IResult> UpdateProductType(ProductTypeUpdateDto productTypeUpdateDto, Guid modifiedUser);
    }
}
