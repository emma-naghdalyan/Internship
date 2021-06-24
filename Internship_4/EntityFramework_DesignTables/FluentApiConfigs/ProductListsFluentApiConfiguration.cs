using EntityFramework_DesignTables.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.FluentApiConfigs
{
    public class ProductListsFluentApiConfiguration : IEntityTypeConfiguration<ProductList>
    {
        public void Configure(EntityTypeBuilder<ProductList> builder)
        {
            builder
                .HasKey(pl => pl.ProductListId);

            builder
                .HasOne(pl => pl.Inventory)
                .WithMany(i => i.ProductLists)
                .HasForeignKey(pl => pl.InventoryId);

            builder
                .Property(pl => pl.Package).HasMaxLength(4);

            builder
                .HasMany(pl => pl.Products)
                .WithOne(p => p.ProductList)
                .IsRequired();

            //builder.HasData(new ProductList
            //{
            //    ProductListId = 1,
            //    Package = 3
            //});
        }
    }
}
