using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Framework.Utilities;
using Microsoft.EntityFrameworkCore;
using MyWebSiteBackend.domain.Models;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations;

namespace MyWebSiteBackend.persistance.DbContexts
{
    public class MyWebSiteDbContext:DbContext
    {
        public MyWebSiteDbContext(DbContextOptions<MyWebSiteDbContext> options):base(options)
        {
            
        }

        public DbSet<Article> articles { get; set; }
        public DbSet<ArticleImage> articleImages { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Keyword> keywords { get; set; }
        public DbSet<MetaTag> metaTags { get; set; }
        public DbSet<ReadMore> readMores { get; set; }
        public DbSet<Reference> references { get; set; }
        public DbSet<RelatedArticle> relatedArticles { get; set; }
        public DbSet<SubArticle> subArticles { get; set; }
        public DbSet<SubArticleImage> subArticleImage { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Article>(new ArticleConfig());
            modelBuilder.ApplyConfiguration<ArticleImage>(new ArticleImageConfig());
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfig());
            modelBuilder.ApplyConfiguration<Comment>(new CommentConfig());
            modelBuilder.ApplyConfiguration<Keyword>(new KeywordConfig());
            modelBuilder.ApplyConfiguration<MetaTag>(new MetaTagConfig());
            modelBuilder.ApplyConfiguration<ReadMore>(new ReadMoreConfig());
            modelBuilder.ApplyConfiguration<Reference>(new ReferenceConfig());
            modelBuilder.ApplyConfiguration<SubArticle>(new SubArticleConfig());
            modelBuilder.ApplyConfiguration<SubArticleImage>(new SubArticleImageConfig());
            
            
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=default)
        {
            DateTime dt = new DateTime();
            foreach(var entry in ChangeTracker.Entries<BaseModel>())
            {
                if(entry.State==EntityState.Added)
                {
                    entry.Entity.CreatedDate = dt.ToPersianCalendar();
                    
                }
                entry.Entity.ModifiedDate = dt.ToPersianCalendar();

            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
