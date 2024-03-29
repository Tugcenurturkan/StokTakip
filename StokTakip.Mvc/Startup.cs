using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StokTakip.Mvc.AutoMapper.Profiles;
using StokTakip.Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StokTakip.Mvc
{
    public class Startup
    {
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });
            services.AddSession();
            services.AddAutoMapper(typeof(UserProfile),typeof(ProductActivityProfile), typeof(ProductTypeProfile));
            services.LoadMyServices();
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/User/Login");
                options.LogoutPath = new PathString("/User/Logout");
                options.Cookie = new CookieBuilder
                {
                    Name = "StokTakip",
                    HttpOnly = true, //xss sald�r�lar�n� �nlemek i�in
                    SameSite = SameSiteMode.Strict, //csrf sald�r�lar�n� �nlemek i�in
                    SecurePolicy = CookieSecurePolicy.SameAsRequest
                };
                options.SlidingExpiration = true; //oturum a��k kalma s�resi
                options.ExpireTimeSpan = System.TimeSpan.FromDays(1); //kullan�c� bir g�n boyunca tekrar giri� yapmak zorunda kalmayacak
                options.AccessDeniedPath = new PathString("/User/AccessDenied"); 
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Dashboard}/{id?}");
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
