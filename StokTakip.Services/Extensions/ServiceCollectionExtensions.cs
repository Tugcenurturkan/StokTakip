﻿using Microsoft.Extensions.DependencyInjection;
using StokTakip.Data.Abstract;
using StokTakip.Data.Concrete;
using StokTakip.Data.Concrete.EntityFramework.Context;
using StokTakip.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<StokTakipContext>();
            serviceCollection.AddIdentity<User, Role>(options=> 
            {
                //user password options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                //user username and email options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<StokTakipContext>(); 
            //alt satır hata veriyor buna kullanıcı girişini tamaladıktan sonra mutlaka bak
            //serviceCollection.AddScoped<IUnitOfWork,UnitOfWork>();
            //serviceCollection.AddScoped<IProductTypeService,ProductTypeManager>();
            //serviceCollection.AddScoped<IProductDefinitionService,ProductDefinitionManager>();
            return serviceCollection;
        }
    }
}
