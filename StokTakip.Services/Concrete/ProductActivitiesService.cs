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
    public class ProductActivitiesService : IProductActivitiesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductActivitiesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ProductActivitiesDto>> Add(ProductActivitiesAddDto productDefinitionAddDto)
        {
            var product = _mapper.Map<ProductActivity>(productDefinitionAddDto);
            var addedProduct = await _unitOfWork.ProductActivities.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductActivitiesDto>(ResultStatus.Success, $"{productDefinitionAddDto.Name} adlı ürün başarıyla eklenmiştir.",
                 new ProductActivitiesDto
                 {
                     ProductActivity = addedProduct,
                     ResultStatus = ResultStatus.Success,
                     Message = $"{productDefinitionAddDto.Name} adlı ürün başarıyla eklenmiştir."
                 });
        }

        public async Task<IDataResult<ProductActivitiesDto>> Delete(Guid productDefinitionId)
        {
            var product = await _unitOfWork.ProductActivities.GetAsync(x => x.ID == productDefinitionId && x.IsActive && !x.IsDeleted);
            if (product != null)
            {
                product.IsDeleted = true;
                var deletedProduct = await _unitOfWork.ProductActivities.UpdateAsync(product);
                await _unitOfWork.SaveAsync();
                return new DataResult<ProductActivitiesDto>(ResultStatus.Success, $"{deletedProduct.Name} adlı ürün başarıyla silinmiştir.", new ProductActivitiesDto
                {
                    ProductActivity = deletedProduct,
                    ResultStatus = ResultStatus.Success,
                    Message = $"{deletedProduct.Name} adlı ürün başarıyla silinmiştir."
                });
            }
            return new DataResult<ProductActivitiesDto>(ResultStatus.Error, $"Böyle bir ürün bulunamadı.", new ProductActivitiesDto
            {
                ProductActivity = null,
                ResultStatus = ResultStatus.Error,
                Message = $"Böyle bir ürün bulunamadı."
            });
        }

        public async Task<IDataResult<ProductActivitiesDto>> GetById(Guid productDefinitionId)
        {
            var product = await _unitOfWork.ProductActivities.GetAsync(x => x.ID == productDefinitionId && x.IsActive && !x.IsDeleted, x => x.ProductType);
            if (product != null)
            {
                return new DataResult<ProductActivitiesDto>(ResultStatus.Success, new ProductActivitiesDto
                {
                    ProductActivity = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductActivitiesDto>(ResultStatus.Error, "Böyle Bir ürün bulunamadı", null);
        }

        public async Task<IDataResult<ProductActivitiesListDto>> GetAll()
        {
            var products = await _unitOfWork.ProductActivities.GetAllAsync(x => x.IsActive && !x.IsDeleted, x => x.ProductType);
            if (products.Count > -1)
            {
                return new DataResult<ProductActivitiesListDto>(ResultStatus.Success, new ProductActivitiesListDto
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductActivitiesListDto>(ResultStatus.Error, "Ürün Bulunamadı", null);
        }

        public async Task<IDataResult<ProductActivitiesDto>> Update(ProductActivitiesUpdateDto productDefinitionUpdateDto)
        {
            var oldproduct = await _unitOfWork.ProductActivities.GetAsync(x => x.ID == productDefinitionUpdateDto.Id);
            var product = _mapper.Map<ProductActivitiesUpdateDto, ProductActivity>(productDefinitionUpdateDto, oldproduct);
            var updatedProduct = await _unitOfWork.ProductActivities.UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            return new DataResult<ProductActivitiesDto>(ResultStatus.Success, $"{productDefinitionUpdateDto.Name} adlı ürün başarıyla güncellenmiştir.", new ProductActivitiesDto
            {
                ProductActivity = updatedProduct,
                ResultStatus = ResultStatus.Success,
                Message = $"{productDefinitionUpdateDto.Name} adlı ürün başarıyla güncellenmiştir."
            });
        }
        public async Task<IDataResult<ProductActivitiesUpdateDto>> GetProductActivityUpdateDto(Guid productDefinitionId)
        {
            var result = await _unitOfWork.ProductActivities.AnyAsync(x => x.ID == productDefinitionId);
            if (result)
            {
                var productDefinition = await _unitOfWork.ProductActivities.GetAsync(x => x.ID == productDefinitionId);
                var productDefinitionUpdateDto = _mapper.Map<ProductActivitiesUpdateDto>(productDefinition);
                return new DataResult<ProductActivitiesUpdateDto>(ResultStatus.Success, productDefinitionUpdateDto);
            }
            else
            {
                return new DataResult<ProductActivitiesUpdateDto>(ResultStatus.Error, "Böyle bir ürün türü bulunamadı.", null);
            }
        }
    }
}
