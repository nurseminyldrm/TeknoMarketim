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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.OrderNumber).IsRequired().HasMaxLength(50);
            builder.Property(e => e.OrderDate).IsRequired().HasMaxLength(75);
            builder.Property(e => e.UserId).IsRequired().HasMaxLength(50);
            builder.Property(e => e.OrderState).IsRequired().HasMaxLength(50);
            builder.Property(e => e.PaymentTypes).IsRequired().HasConversion<int>();

            builder.HasMany(e=>e.OrderItems).
                WithOne(oi=>oi.Order)
                .HasForeignKey(oi=>oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Address).IsRequired().HasMaxLength(200);
            builder.Property(e => e.City).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Phone).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.OrderNote).HasMaxLength(500);
            builder.Property(e => e.Status).IsRequired().HasDefaultValue(true);

            builder.Property(e => e.CardName).HasMaxLength(50);
            builder.Property(e => e.CardNumber).HasMaxLength(16);
            builder.Property(e => e.ExpirationMonth).HasMaxLength(2);
            builder.Property(e => e.ExpirationYear).HasMaxLength(4);
            builder.Property(e => e.Cvv).HasMaxLength(3);

            builder.Property(e => e.PaymentId);
            builder.Property(e => e.PaymentToken).HasMaxLength(200);
            builder.Property(e => e.ConversationId).HasMaxLength(100);
        }
    }
}
