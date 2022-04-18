using StokTakip.Entities.Concrete;
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
    public class ProductDefinitionAddDto
    {
        [DisplayName("Barkod")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(20, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        public string Barcode { get; set; }
        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden büyük olmamalıdır.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public decimal Price { get; set; }
        [DisplayName("Miktar")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int Amount { get; set; }
        [DisplayName("Giriş Tarihi")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public DateTime Date { get; set; }
        [DisplayName("Beden")]
        [Required(ErrorMessage = "{0} boş geçilmemelidir.")]
        public int Size { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}
