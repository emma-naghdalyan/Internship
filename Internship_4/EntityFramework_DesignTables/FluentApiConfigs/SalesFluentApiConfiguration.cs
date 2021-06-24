using EntityFramework_DesignTables.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.FluentApiConfigs
{
    public class SalesFluentApiConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                .HasKey(s => s.SaleId);

            builder
                .Property(s => s.DateSold)
                .HasComputedColumnSql("GetUtcDate()")
                .IsRequired();

            builder
                .HasOne(s => s.Product)
                .WithOne(p => p.Sale)
                .HasForeignKey<Sale>(s => s.SaleId);
        }
    }
}
