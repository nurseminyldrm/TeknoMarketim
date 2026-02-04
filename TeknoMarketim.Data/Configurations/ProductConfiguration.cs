using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Brand).IsRequired().HasMaxLength(100);
        builder.Property(e => e.ImageUrl).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(1000);
        builder.Property(e => e.Price).HasColumnType("decimal(10,2)");
        builder.Property(e => e.DiscountedPrice).HasColumnType("decimal(10,2)");
        builder.Property(e => e.StockQuantity).IsRequired();
        builder.Property(e => e.isActive).IsRequired();

        builder.Property(e => e.ShowOnPageAsDailyHighLight).HasDefaultValue(false);
        builder.Property(e => e.ShowOnPageAsMonthlyHighLight).HasDefaultValue(false);
        builder.Property(e => e.ShowOnPageAsPopular).HasDefaultValue(false);
        builder.Property(e => e.ShowOnPageAsSpecialOffer).HasDefaultValue(false);

        //ilişki : Product - ProductCategory (1-N)
        builder.HasMany(p=>p.ProductCategories)
            .WithOne()
            .HasForeignKey(pc => pc.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
