using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyWebSiteBackend.persistance.DbContexts;

namespace MyWebSiteBackend.persistance
{
    public class MyWebSiteDbContextFactory:IDesignTimeDbContextFactory<MyWebSiteDbContext>
    {
        public MyWebSiteDbContext CreateDbContext(string[] args)
        {
            var configurations = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder= new DbContextOptionsBuilder<MyWebSiteDbContext>();
            string connectionString = configurations.GetConnectionString("MyWebSiteConnectionString");
            builder.UseSqlServer(connectionString);
            return  new MyWebSiteDbContext(builder.Options);
        }
    }
}
