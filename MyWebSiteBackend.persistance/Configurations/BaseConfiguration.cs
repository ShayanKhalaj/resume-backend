using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyWebSiteBackend.domain.Models;

namespace MyWebSiteBackend.persistance.Configurations
{
    public class BaseConfiguration:IEntityTypeConfiguration<BaseModel>
    {
        public void Configure(EntityTypeBuilder<BaseModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedBy).HasMaxLength(100);
            builder.Property(x => x.CreatedDate).HasMaxLength(30);
            builder.Property(x => x.ModifiedBy).HasMaxLength(100);
            builder.Property(x => x.ModifiedDate).HasMaxLength(30);
            builder.Property(x => x.Description).HasMaxLength(500);
        }
    }
}
