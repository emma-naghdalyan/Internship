using EntityFramework_DesignTables.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.FluentApiConfigs
{
    public class InventoriesFluentApiConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasKey(i => i.InventoryId);

            builder
                .HasMany(i => i.ProductLists)
                .WithOne(p => p.Inventory);

            builder
                .Property(i => i.Type)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(i => i.SerialNumber)
                .IsRequired();
        }
    }
}
