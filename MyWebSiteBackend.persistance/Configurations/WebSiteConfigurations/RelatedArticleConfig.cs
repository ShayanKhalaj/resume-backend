using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class RelatedArticleConfig:BaseConfiguration,IEntityTypeConfiguration<RelatedArticle>
    {
        public void Configure(EntityTypeBuilder<RelatedArticle> builder)
        {
            builder.Property(x => x.RelationName).HasMaxLength(100).IsRequired();
        }
    }
}
