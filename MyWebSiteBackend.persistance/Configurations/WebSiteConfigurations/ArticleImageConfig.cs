using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class ArticleImageConfig :BaseConfiguration, IEntityTypeConfiguration<ArticleImage>
    {
        public void Configure(EntityTypeBuilder<ArticleImage> builder)
        {
            builder.Property(x => x.ImageUrl).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.alter).HasMaxLength(500).IsRequired();
            builder.Property(x => x.ArticleID).HasDefaultValue(0).IsRequired();
        }
    }
}
