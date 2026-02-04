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
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.Property(e => e.Description).IsRequired().HasMaxLength(100);
        }
    }
}
