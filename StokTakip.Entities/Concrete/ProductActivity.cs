using StokTakip.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Entities.Concrete
{
    public class ProductActivity : EntityBase,IEntity
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public int Size { get; set; }
        public Guid ProductTypeId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ProductType ProductType { get; set; }
        public int ActivityType { get; set; } // 1 giriş 2 çıkış
    }
}
