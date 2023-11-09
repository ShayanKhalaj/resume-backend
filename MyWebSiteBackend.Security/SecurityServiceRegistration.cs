using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebSiteBackend.Security.Models;

namespace MyWebSiteBackend.Security
{
    public static class SecurityServiceRegistration
    {
        public static IServiceCollection ConfigureSecurityServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<MyWebSiteSecurityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SecurityConnectionString"));
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>(option =>
            {
                option.Password.RequireDigit = true;
                option.Password.RequireUppercase = true;
                option.Lockout.MaxFailedAccessAttempts = 10;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            }).AddEntityFrameworkStores<MyWebSiteSecurityDbContext>();
            return services;
        }
    }
}