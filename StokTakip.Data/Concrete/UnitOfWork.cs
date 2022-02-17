using StokTakip.Data.Abstract;
using StokTakip.Data.Concrete.EntityFramework.Context;
using StokTakip.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StokTakipContext _context;
        private EfProductDefinitionRepository _productDefinitionRepository;
        private EfProductTypeRepository _productTypeRepository;
        public UnitOfWork(StokTakipContext context, EfProductDefinitionRepository productDefinitionRepository, EfProductTypeRepository productTypeRepository)
        {
            _context = context;
            _productDefinitionRepository = productDefinitionRepository;
            _productTypeRepository = productTypeRepository;
        }
        public IProductDefinitionRepository ProductDefinitions => _productDefinitionRepository ?? new EfProductDefinitionRepository(_context);

        public IProductTypeRepository ProductTypes => _productTypeRepository ?? new EfProductTypeRepository(_context);

        public async ValueTask DisposeAsync() //bu ne????
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
