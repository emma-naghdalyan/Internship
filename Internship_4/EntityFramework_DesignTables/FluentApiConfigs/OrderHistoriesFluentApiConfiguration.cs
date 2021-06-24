using EntityFramework_DesignTables.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.FluentApiConfigs
{
    public class OrderHistoriesFluentApiConfiguration : IEntityTypeConfiguration<OrderHistory>
    {
        public void Configure(EntityTypeBuilder<OrderHistory> builder)
        {
            builder
                .HasKey(oh => oh.OrderHistoryId);

            builder
                .HasOne(oh => oh.Customer)
                .WithOne(c => c.OrderHistory)
                .IsRequired();
        }
    }
}
