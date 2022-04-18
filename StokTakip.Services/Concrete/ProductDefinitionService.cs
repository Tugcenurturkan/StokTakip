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
    public class ProductDefinitionService : IProductDefinitionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductDefinitionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult> Add(ProductDefinitionAddDto productDefinitionAddDto, Guid createdUser)
        {
            var product = _mapper.Map<ProductDefinition>(productDefinitionAddDto);
            product.CreatedUserId = createdUser;
            product.ModifiedUserId = createdUser;
            await _unitOfWork.ProductDefinitions.AddAsync(product).ContinueWith(x=>_unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{productDefinitionAddDto.Name} adlı ürün başarıyla eklenmiştir.");
        }

        public async Task<IResult> Delete(Guid productDefinitionId, string modifiedByName)
        {
            var product = await _unitOfWork.ProductDefinitions.GetAsync(x => x.ID == productDefinitionId && x.IsActive && !x.IsDeleted);
            if (product != null)
            {
                product.IsDeleted = true;
                product.ModifiedUserId = Guid.Parse(modifiedByName);
                product.ModifiedTime = DateTime.Now;
                await _unitOfWork.ProductDefinitions.UpdateAsync(product).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{product.Name} adlı ürün başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle Bir ürün bulunamadı");
        }

        public async Task<IDataResult<ProductDefinitionDto>> GetById(Guid productDefinitionId)
        {
            var product = await _unitOfWork.ProductDefinitions.GetAsync(x => x.ID == productDefinitionId && x.IsActive && !x.IsDeleted, x => x.ProductType);
            if (product != null)
            {
                return new DataResult<ProductDefinitionDto>(ResultStatus.Success, new ProductDefinitionDto 
                {
                    ProductDefinition = product,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductDefinitionDto>(ResultStatus.Error, "Böyle Bir ürün bulunamadı",null);
        }

        public async Task<IDataResult<ProductDefinitionListDto>> GetAll()
        {
            var products = await _unitOfWork.ProductDefinitions.GetAllAsync(x=> x.IsActive && !x.IsDeleted,x=>x.ProductType);
            if (products.Count>-1)
            {
                return new DataResult<ProductDefinitionListDto>(ResultStatus.Success, new ProductDefinitionListDto 
                {
                    Products = products,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<ProductDefinitionListDto>(ResultStatus.Error, "Ürün Bulunamadı", null);
        }

        public async Task<IResult> Update(ProductDefinitionUpdateDto productDefinitionUpdateDto, Guid modifiedUser)
        {
            var product = _mapper.Map<ProductDefinition>(productDefinitionUpdateDto);
            product.ModifiedUserId = modifiedUser;
            await _unitOfWork.ProductDefinitions.UpdateAsync(product).ContinueWith(x => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{productDefinitionUpdateDto.Name} adlı ürün başarıyla güncellenmiştir.");
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




        public async Task<IResult> AddProductType(ProductTypeAddDto productTypeAddDto, Guid createdUser)
        {
            var productType = _mapper.Map<ProductType>(productTypeAddDto);
            productType.CreatedUserId = createdUser;
            productType.ModifiedUserId = createdUser;
            await _unitOfWork.ProductTypes.AddAsync(productType).ContinueWith(x => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{productTypeAddDto.Name} adlı ürün türü başarıyla eklenmiştir.");
        }

        public async Task<IResult> DeleteProductType(Guid productTypeId, string modifiedByName)
        {
            var productType = await _unitOfWork.ProductTypes.GetAsync(x => x.ID == productTypeId && x.IsActive && !x.IsDeleted);
            if (productType != null)
            {
                productType.IsDeleted = true;
                productType.ModifiedUserId = Guid.Parse(modifiedByName);
                productType.ModifiedTime = DateTime.Now;
                await _unitOfWork.ProductTypes.UpdateAsync(productType).ContinueWith(x => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{productType.Name} adlı ürün türü başarıyla silinmiştir.");
            }
            return new Result(ResultStatus.Error, "Böyle Bir ürün türü bulunamadı");
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
        public async Task<IResult> UpdateProductType(ProductTypeUpdateDto productTypeUpdateDto, Guid modifiedUser)
        {
            var productType = _mapper.Map<ProductType>(productTypeUpdateDto);
            productType.ModifiedUserId = modifiedUser;
            await _unitOfWork.ProductTypes.UpdateAsync(productType).ContinueWith(x => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{productTypeUpdateDto.Name} adlı ürün türü başarıyla güncellenmiştir.");
        }
    }
}
