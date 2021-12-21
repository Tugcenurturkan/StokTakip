using StokTakip.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Concrete
{
    public class User : EntityBase, IEntity
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public byte[] UserPassword { get; set; }
        public string UserPhone { get; set; }
        [NotMapped]
        public string UserFullName
        {
            get { return this.UserName + " " + this.UserSurname; }
        }
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
