using StokTakip.Entities.Concrete;
using StokTakip.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Dtos
{
    public class UserRoleListDto:DtoGetBase
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public List<UserRoleListDto> UserRoleList { get; set; }
    }
}
