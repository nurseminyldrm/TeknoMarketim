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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(c=>c.CartItems)
                .WithOne(ci=>ci.Cart)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(c => c.WishLists)
                .WithOne()
                .HasForeignKey("CartId")
                .OnDelete(deleteBehavior:DeleteBehavior.Cascade);
        }
    }
}
