using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class ReferenceConfig :BaseConfiguration, IEntityTypeConfiguration<Reference>
    {
        public void Configure(EntityTypeBuilder<Reference> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Text).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.Link).HasMaxLength(2000);
            builder.Property(x => x.ArticleID).HasDefaultValue(0).IsRequired();
        }
    }
}
