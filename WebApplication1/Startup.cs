using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRestFulFactoryPattern.App.Applications;
using WebRestFulFactoryPattern.Data;
using WebRestFulFactoryPattern.Permission;

namespace WebRestFulFactoryPattern
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            foreach(var i  in RegisteredService.GetService())
            {
                services.AddSingleton(i.Value.Item1, i.Value.Item2);
            }
            /*   services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
               services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
               //services.Add(new ServiceDescriptor(typeof(IAuditAppService), new AuditAppService()));
          *//*     services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("DefaultConnection")));
             *//*
               services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AlinjewelrycoreContextConnection")));
               services.AddIdentity<IdentityUser, IdentityRole>()
                   .AddEntityFrameworkStores<ApplicationDbContext>();
               services.AddControllersWithViews();
               services.AddRazorPages();*/

            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AlinjewelrycoreContextConnection")));
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultUI()
            .AddDefaultTokenProviders();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}