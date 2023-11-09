using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class ArticleConfig : BaseConfiguration,IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(5000).IsRequired();
            builder.Property(x => x.AudioUrl).HasMaxLength(2000);
            builder.Property(x => x.AudioDescription).HasMaxLength(2000);
            builder.Property(x => x.VideoUrl).HasMaxLength(2000);
            builder.Property(x => x.VideoDescription).HasMaxLength(2000);
            builder.Property(x => x.CategoryID).HasDefaultValue(0).IsRequired();
            builder.HasMany(x => x.Images)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.RelatedArticles)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.References)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Keywords)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.MetaTags)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.SubArticles)
                .WithOne(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
