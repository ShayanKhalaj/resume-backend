using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyWebSiteBackend.application.Contracts;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.persistance.DbContexts;
using MyWebSiteBackend.persistance.Repositories;
using MyWebSiteBackend.persistance.Repositories.WebSiteRepositories;

namespace MyWebSiteBackend.persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices (this IServiceCollection services,IConfiguration configurations)
        {
            services.AddDbContext<MyWebSiteDbContext>(options =>
            {
                options.UseSqlServer(configurations.GetConnectionString("MyWebSiteConnectionString"));
            },ServiceLifetime.Scoped);
            
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            
            services.AddScoped<IArticleRepository,ArticleRepository>();
            
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IArticleImageRepository, ArticleImageRepository>();
            
            services.AddScoped<ICommentRepository, CommentRepository>();
            
            services.AddScoped<IKeywordRepository, KeywordRepository>();

            services.AddScoped<IMetaTagRepository, MetaTagRepository>();

            services.AddScoped<IReadMoreRepository, ReadMoreRepository>();

            services.AddScoped<IReferenceRepository, ReferenceRepository>();

            services.AddScoped<IRelatedArticleRepository, RelatedArticleRepository>();

            services.AddScoped<ISubArticleRepository, SubArticleRepository>();

            services.AddScoped<ISubArticleImageRepository, SubArticleImageRepository>();
            
            return services;
        }
    }
}
