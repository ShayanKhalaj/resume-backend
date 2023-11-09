using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.persistance.Configurations.WebSiteConfigurations
{
    public class CategoryConfig :BaseConfiguration, IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.CategoryName).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ImageUrl).HasMaxLength(2000);
            builder.Property(x => x.ImageAlter).HasMaxLength(500);
            builder.HasMany(x => x.Articles).WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.NoAction);


        }
    }
}
