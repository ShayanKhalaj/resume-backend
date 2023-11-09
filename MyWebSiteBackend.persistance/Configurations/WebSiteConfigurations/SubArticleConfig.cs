using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class SubArticleConfig :BaseConfiguration, IEntityTypeConfiguration<SubArticle>
    {
        public void Configure(EntityTypeBuilder<SubArticle> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(5000).IsRequired();
            builder.Property(x => x.VideoUrl).HasMaxLength(2000);
            builder.Property(x => x.VideoDescription).HasMaxLength(500);
            builder.Property(x => x.AudioUrl).HasMaxLength(2000);
            builder.Property(x => x.AudioDescription).HasMaxLength(500);
            builder.Property(x => x.ArticleID).HasDefaultValue(0).IsRequired();
            builder.HasMany(x => x.Images).WithOne(x => x.SubArticle)
                .HasForeignKey(x => x.SubArticleID).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ReadMores).WithOne(x => x.SubArticle)
                .HasForeignKey(x => x.SubArticleID).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
