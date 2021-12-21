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
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.RoleName).HasMaxLength(30);
            builder.Property(x => x.RoleName).IsRequired();
            builder.Property(x => x.RoleDescription).HasMaxLength(100);
            builder.Property(x => x.RoleDescription).IsRequired();
            builder.Property(x => x.CreatedUserId).HasMaxLength(100);
            builder.Property(x => x.CreatedUserId).IsRequired();
            builder.Property(x => x.ModifiedUserId).HasMaxLength(100);
            builder.Property(x => x.ModifiedUserId).IsRequired();
            builder.Property(x => x.CreatedTime).IsRequired();
            builder.Property(x => x.ModifiedTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.ToTable("Role");
        }
    }
}
