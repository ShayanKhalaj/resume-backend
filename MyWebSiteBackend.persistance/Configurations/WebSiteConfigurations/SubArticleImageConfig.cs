using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class SubArticleImageConfig :BaseConfiguration, IEntityTypeConfiguration<SubArticleImage>
    {
        public void Configure(EntityTypeBuilder<SubArticleImage> builder)
        {
            builder.Property(x => x.ImageUrl).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.Alter).HasMaxLength(500).IsRequired();
            builder.Property(x => x.SubArticleID).HasDefaultValue(0).IsRequired();
        }
    }
}
