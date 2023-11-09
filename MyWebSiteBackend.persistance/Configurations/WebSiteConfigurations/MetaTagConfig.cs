using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class MetaTagConfig :BaseConfiguration, IEntityTypeConfiguration<MetaTag>
    {
        public void Configure(EntityTypeBuilder<MetaTag> builder)
        {
            builder.Property(x => x.Tag).HasMaxLength(500).IsRequired();
            builder.Property(x => x.TagName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.ArticleID).HasDefaultValue(0).IsRequired();
        }
    }
}
