using StokTakip.Entities.Concrete;
using StokTakip.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Dtos
{
    class UserRoleDto : DtoGetBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
