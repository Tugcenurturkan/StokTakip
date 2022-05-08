using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IProductActivityRepository ProductActivities { get; }
        IProductTypeRepository ProductTypes { get; }
        Task<int> SaveAsync();
    }
}
