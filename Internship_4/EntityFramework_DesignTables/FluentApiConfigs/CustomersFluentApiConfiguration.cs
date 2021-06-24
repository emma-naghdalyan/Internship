using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework_DesignTables.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFramework_DesignTables.FluentApiConfigs
{
    public class CustomersFluentApiConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasKey(c => c.CustomerId);

            builder
                .HasOne(c => c.OrderHistory)
                .WithOne(i => i.Customer)
                .HasForeignKey<OrderHistory>(c => c.OrderHistoryId);

            builder
                .Property(c => c.Name)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(c => c.Address)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
