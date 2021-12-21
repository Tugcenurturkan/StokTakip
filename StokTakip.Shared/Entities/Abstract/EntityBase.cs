using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public virtual Guid ID { get; set; }
        public virtual DateTime CreatedTime { get; set; } = DateTime.Now;
        public virtual DateTime ModifiedTime { get; set; } = DateTime.Now;
        public virtual bool IsDeleted { get; set; } = false;
        public virtual bool IsActive { get; set; } = true;
        public virtual Guid CreatedUserId { get; set; }
        public virtual Guid ModifiedUserId { get; set; }
    }
}
