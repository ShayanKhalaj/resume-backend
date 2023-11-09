using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.Security.Models;

namespace MyWebSiteBackend.Security
{
    public class MyWebSiteSecurityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public MyWebSiteSecurityDbContext(DbContextOptions<MyWebSiteSecurityDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<ApplicationRole> applicationRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserRole>().HasKey(x => x.Id);
            builder.Entity<ApplicationUser>().HasKey(x => x.Id);
            builder.Entity<ApplicationRole>().HasKey(x => x.Id);
            builder.Entity<ApplicationUser>().HasMany(x => x.ApplicationUserRoles)
                .WithOne(x => x.User).HasForeignKey(x => x.FKUserID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ApplicationRole>().HasMany(x => x.ApplicationUserRoles)
                .WithOne(x => x.Role).HasForeignKey(x => x.FKRoleID)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(builder);
        }
    }
}