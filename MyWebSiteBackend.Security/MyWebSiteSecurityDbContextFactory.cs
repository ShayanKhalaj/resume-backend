using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MyWebSiteBackend.Security
{
    public class MyWebSiteSecurityDbContextFactory : IDesignTimeDbContextFactory<MyWebSiteSecurityDbContext>
    {
        public MyWebSiteSecurityDbContext CreateDbContext(string[] args)
        {
            var configurations = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json")
                .Build();
            var builder = new DbContextOptionsBuilder<MyWebSiteSecurityDbContext>();
            string connectionString = configurations.GetConnectionString("MyWebSiteConnectionString");
            builder.UseSqlServer(connectionString);
            return new MyWebSiteSecurityDbContext(builder.Options);
        }
    }
}