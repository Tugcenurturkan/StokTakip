using Microsoft.EntityFrameworkCore;
using StokTakip.Data.Abstract;
using StokTakip.Entities.Concrete;
using StokTakip.Shared.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Concrete.EntityFramework.Repositories
{
    public class EfProductDefinitionRepository : EfEntityRepositoryBase<ProductDefinition>,IProductDefinitionRepository
    {
        public EfProductDefinitionRepository(DbContext context) : base(context)
        {
             
        }
    }
}
