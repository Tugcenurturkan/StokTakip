using StokTakip.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Dtos
{
    public class UserRoleAddDto
    {
        [DisplayName("Kullanıcı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public string UserName { get; set; }
        [DisplayName("Rol")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public string RoleName { get; set; }
    }
}
