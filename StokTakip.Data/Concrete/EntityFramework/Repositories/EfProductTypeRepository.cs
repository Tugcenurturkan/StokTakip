using Microsoft.EntityFrameworkCore;
using StokTakip.Data.Abstract;
using StokTakip.Entities.Concrete;
using StokTakip.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Concrete.EntityFramework.Repositories
{
    public class EfProductTypeRepository : EfEntityRepositoryBase<ProductType>, IProductTypeRepository
    {
        public EfProductTypeRepository(DbContext context) : base(context)
        {

        }
    }
}
