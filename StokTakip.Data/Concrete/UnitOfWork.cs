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
        private EfProductActivityRepository _efProductActivityRepository;
        private EfProductTypeRepository _efProductTypeRepository;
        public UnitOfWork(StokTakipContext context)
        {
            _context = context;
        }
        public IProductActivityRepository ProductActivities => _efProductActivityRepository ?? new EfProductActivityRepository(_context);

        public IProductTypeRepository ProductTypes => _efProductTypeRepository ?? new EfProductTypeRepository(_context);

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync() //bu ne????
        {
            await _context.DisposeAsync();
        }

        
    }
}
