using AutoMapper;
using StokTakip.Data.Abstract;
using StokTakip.Entities.Concrete;
using StokTakip.Entities.Dtos;
using StokTakip.Services.Abstract;
using StokTakip.Shared.Utilities.Results.Abstract;
using StokTakip.Shared.Utilities.Results.ComplexTypes;
using StokTakip.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services.Concrete
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ProductTypeListDto>> GetAllProductType()
        {
            var productType = await _unitOfWork.ProductTypes.GetAllAsync(x => x.IsActive && !x.IsDeleted);
            if (productType.Count > -1)
            {
                return new DataResult<ProductTypeListDto>(ResultStatus.Success, new ProductTypeListDto
                {
                    ProductTypes = productType,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductTypeListDto>(ResultStatus.Error, "Ürün türü Bulunamadı", null);
        }




        public async Task<IDataResult<ProductTypeDto>> AddProductType(ProductTypeAddDto productTypeAddDto)
        {
            var productType = _mapper.Map<ProductType>(productTypeAddDto);
            var addedProductType = await _unitOfWork.ProductTypes.AddAsync(productType);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductTypeDto>(ResultStatus.Success, $"{productTypeAddDto.Name} adlı ürün türü başarıyla eklenmiştir.",
                 new ProductTypeDto
                 {
                     ProductType = addedProductType,
                     ResultStatus = ResultStatus.Success,
                     Message = $"{productTypeAddDto.Name} adlı ürün türü başarıyla eklenmiştir."
                 });
        }

        public async Task<IDataResult<ProductTypeDto>> DeleteProductType(Guid productTypeId)
        {
            var productType = await _unitOfWork.ProductTypes.GetAsync(x => x.ID == productTypeId && x.IsActive && !x.IsDeleted);
            if (productType != null)
            {
                productType.IsDeleted = true;
                var deletedProductType = await _unitOfWork.ProductTypes.UpdateAsync(productType);
                await _unitOfWork.SaveAsync();
                return new DataResult<ProductTypeDto>(ResultStatus.Success, $"{deletedProductType.Name} adlı ürün türü başarıyla silinmiştir.", new ProductTypeDto
                {
                    ProductType = deletedProductType,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedProductType.Name} adlı ürün türü başarıyla silinmiştir."
                });
            }
            return new DataResult<ProductTypeDto>(ResultStatus.Error, $"Böyle bir ürün türü bulunamadı.", new ProductTypeDto
            {
                ProductType = null,
                ResultStatus = ResultStatus.Error,
                Message = $"Böyle bir ürün türü bulunamadı."
            });
        }

        public async Task<IDataResult<ProductTypeDto>> GetByIdProductType(Guid productTypeId)
        {
            var productType = await _unitOfWork.ProductTypes.GetAsync(x => x.ID == productTypeId && x.IsActive && !x.IsDeleted);
            if (productType != null)
            {
                return new DataResult<ProductTypeDto>(ResultStatus.Success, new ProductTypeDto
                {
                    ProductType = productType,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductTypeDto>(ResultStatus.Error, "Böyle Bir ürün türü bulunamadı", null);
        }
        public async Task<IDataResult<ProductTypeDto>> UpdateProductType(ProductTypeUpdateDto productTypeUpdateDto)
        {
            var oldproductType = await _unitOfWork.ProductTypes.GetAsync(x => x.ID == productTypeUpdateDto.Id);
            var productType = _mapper.Map<ProductTypeUpdateDto, ProductType>(productTypeUpdateDto, oldproductType);
            var updatedProductType = await _unitOfWork.ProductTypes.UpdateAsync(productType);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductTypeDto>(ResultStatus.Success, $"{productTypeUpdateDto.Name} adlı ürün başarıyla güncellenmiştir.", new ProductTypeDto
            {
                ProductType = updatedProductType,
                ResultStatus = ResultStatus.Success,
                Message = $"{productTypeUpdateDto.Name} adlı ürün başarıyla güncellenmiştir."
            });
        }
        public async Task<IDataResult<ProductTypeUpdateDto>> GetProductTypeUpdateDto(Guid productTypeId)
        {
            var result = await _unitOfWork.ProductTypes.AnyAsync(x => x.ID == productTypeId);
            if (result)
            {
                var productType = await _unitOfWork.ProductTypes.GetAsync(x => x.ID == productTypeId);
                var productTypeUpdateDto = _mapper.Map<ProductTypeUpdateDto>(productType);
                return new DataResult<ProductTypeUpdateDto>(ResultStatus.Success, productTypeUpdateDto);
            }
            else
            {
                return new DataResult<ProductTypeUpdateDto>(ResultStatus.Error, "Böyle bir ürün türü bulunamadı.", null);
            }
        }
    }
}
