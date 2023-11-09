using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class ReadMoreConfig :BaseConfiguration, IEntityTypeConfiguration<ReadMore>
    {
        public void Configure(EntityTypeBuilder<ReadMore> builder)
        {
            builder.Property(x => x.LinkText).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.LinkName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.SubArticleID).HasDefaultValue(0).IsRequired();
        }
    }
}
