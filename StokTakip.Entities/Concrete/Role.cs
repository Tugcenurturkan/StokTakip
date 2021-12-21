using StokTakip.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Concrete
{
    public class Role : EntityBase, IEntity
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public ICollection<User> Users { get; set; }

    }
}
