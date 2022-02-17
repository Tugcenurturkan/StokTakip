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
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new UserRole
            {
                RoleId = new Guid("81a70626-67ca-4266-93c7-1ae06516ba59"),
                UserId = new Guid("7f2474c3-7aa0-4878-9e8e-3f99de1583a0")
            },
            new UserRole
            {
                RoleId = new Guid("ecaf6ccb-a52b-47f2-802d-f14e940e9155"),
                UserId = new Guid("8518ddef-bc48-436b-8fa1-32b34c6206a5")
            }
            );
        }
    }
}
