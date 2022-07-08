using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebRestFulFactoryPattern.Data;
using WebRestFulFactoryPattern.Permission;

[assembly: HostingStartup(typeof(WebRestFulFactoryPattern.Areas.Identity.IdentityHostingStartup))]
namespace WebRestFulFactoryPattern.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {

             

            });
        }
    }
}