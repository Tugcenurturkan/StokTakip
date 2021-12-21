using Microsoft.EntityFrameworkCore;
using StokTakip.Data.Concrete.EntityFramework.Mappings;
using StokTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Data.Concrete.EntityFramework.Context
{
    public class StokTakipContext : DbContext
    {
        DbSet<ProductDefinition> ProductDefinitions { get; set; }
        DbSet<ProductType> ProductTypes { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-L9FD7BP\SQLEXPRESS;Initial Catalog=StokTakip;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductDefinitionMap());
            modelBuilder.ApplyConfiguration(new ProductTypeMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
