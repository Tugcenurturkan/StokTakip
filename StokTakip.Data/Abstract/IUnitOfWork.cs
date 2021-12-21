using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IProductDefinitionRepository ProductDefinitions { get; }
        IProductTypeRepository ProductTypes { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        Task<int> SaveAsync();
    }
}
