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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();
            builder.Property(x => x.UserEmail).IsRequired();
            builder.Property(x => x.UserEmail).HasMaxLength(50);
            builder.HasIndex(x => x.UserEmail).IsUnique();
            builder.Property(x => x.UserName).HasMaxLength(30);
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.UserSurname).HasMaxLength(30);
            builder.Property(x => x.UserSurname).IsRequired();
            builder.Property(x => x.UserPassword).IsRequired();
            builder.Property(x => x.UserPassword).HasColumnType("VARBINARY(500)");
            builder.Property(x => x.CreatedUserId).HasMaxLength(100);
            builder.Property(x => x.CreatedUserId).IsRequired();
            builder.Property(x => x.ModifiedUserId).HasMaxLength(100);
            builder.Property(x => x.ModifiedUserId).IsRequired();
            builder.Property(x => x.CreatedTime).IsRequired();
            builder.Property(x => x.ModifiedTime).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.HasOne<Role>(x => x.Role).WithMany(x => x.Users).HasForeignKey(x => x.RoleId);
            builder.ToTable("User");
        }
    }
}
