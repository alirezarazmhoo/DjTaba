using System;
using DjTaba.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DjTaba.Areas.Identity.IdentityHostingStartup))]
namespace DjTaba.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<ApplicationDbContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("DefaultConnection")));
            //    services.AddDefaultIdentity<ApplicationUser>(options => {
            //        options.SignIn.RequireConfirmedAccount = false;
            //        options.Password.RequireUppercase = false;
            //        options.Password.RequireNonAlphanumeric = false;
            //        options.Password.RequireLowercase = false;
            //    })
            //        .AddEntityFrameworkStores<ApplicationDbContext>();
            //});
        }
    }
}