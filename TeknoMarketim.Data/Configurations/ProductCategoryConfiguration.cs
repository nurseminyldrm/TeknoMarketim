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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc => new {pc.CategoryId, pc.ProductId});

            builder.HasOne(pc => pc.Category)
                .WithMany(c=>c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
        }
    }
}
