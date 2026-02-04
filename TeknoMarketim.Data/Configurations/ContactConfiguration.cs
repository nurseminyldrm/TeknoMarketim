

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeknoMarketim.Entities;

namespace TeknoMarketim.Data.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Message).IsRequired().HasMaxLength(100);
        }
    }
}
