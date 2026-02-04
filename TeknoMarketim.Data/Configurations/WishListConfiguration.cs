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
    public class WishListConfiguration : IEntityTypeConfiguration<WishList
        >
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasOne(w=>w.Product)
                .WithMany()
                .HasForeignKey(w => w.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.Cart)
               .WithMany(c=>c.WishLists)
               .HasForeignKey(w => w.CartId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
