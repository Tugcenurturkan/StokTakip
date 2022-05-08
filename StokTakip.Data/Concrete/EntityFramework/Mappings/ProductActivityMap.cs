using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Concrete.EntityFramework.Mappings
{
    public class ProductActivityMap : IEntityTypeConfiguration<ProductActivity>
    {
        public void Configure(EntityTypeBuilder<ProductActivity> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.Barcode).HasMaxLength(20);
            builder.Property(x => x.Barcode).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Size).IsRequired();
            builder.Property(x => x.ActivityType).IsRequired();
            builder.Property(x => x.CreatedUserId).HasMaxLength(100);
            builder.Property(x => x.CreatedUserId).IsRequired();
            builder.Property(x => x.ModifiedUserId).HasMaxLength(100);
            builder.Property(x => x.ModifiedUserId).IsRequired();
            builder.Property(x => x.CreatedTime).IsRequired();
            builder.Property(x => x.ModifiedTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.ToTable("ProductActivity");
        }
    }
}
