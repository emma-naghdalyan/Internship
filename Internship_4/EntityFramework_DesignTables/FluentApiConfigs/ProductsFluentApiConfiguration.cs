using EntityFramework_DesignTables.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework_DesignTables.FluentApiConfigs
{
    public class ProductsFluentApiConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);

            builder
                .HasOne(p => p.ProductList)
                .WithMany(pl => pl.Products)
                .HasForeignKey(p => p.ProductListId);

            builder
                .Property(p => p.ProductName)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(100);

            builder
                .Property(p => p.DateSold)
                .HasComputedColumnSql("GetUtcDate()")
                .IsRequired();

            builder
                .HasOne(p => p.Sale)
                .WithOne(s => s.Product);

            builder
                .HasOne(p => p.Order)
                .WithMany(o => o.Products);
        }
    }
}
