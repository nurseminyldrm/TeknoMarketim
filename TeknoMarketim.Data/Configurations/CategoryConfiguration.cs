using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Status).IsRequired().HasDefaultValue(true);

            builder.HasMany(c => c.ProductCategories)
                .WithOne()
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
