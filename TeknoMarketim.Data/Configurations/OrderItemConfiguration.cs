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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(e => e.Price).HasColumnType("decimal(18,2)");

            builder.Property(e => e.DiscountPrice)
                .IsRequired()
                .HasPrecision(18, 1);

            builder.Property(e => e.Quantity)
                .IsRequired();

            builder.HasOne(oi => oi.Order)
                .WithMany(o=>o.OrderItems)
                .HasForeignKey(oi=>oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade); //sipariş silinince ilgili ürünler de silinsin

            builder.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi=>oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict); //sipariş siliince ilgili olanlar da silinmesin hata vermesini sağlasın.

        }
    }
}
