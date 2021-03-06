// <auto-generated />
using System;
using EntityFramework_DesignTables.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EntityFramework_DesignTables.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("OrderHistoryId")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Inventory", b =>
                {
                    b.Property<int>("InventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InventoryId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("TrackingNumber")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.OrderHistory", b =>
                {
                    b.Property<int>("OrderHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<double>("UnitSold")
                        .HasColumnType("float");

                    b.HasKey("OrderHistoryId");

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateSold")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("GetUtcDate()");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductListId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("ProductId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductListId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.ProductList", b =>
                {
                    b.Property<int>("ProductListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InventoryId")
                        .HasColumnType("int");

                    b.Property<int>("Package")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductListId");

                    b.HasIndex("InventoryId");

                    b.ToTable("ProductLists");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .HasColumnType("int");

                    b.Property<int>("AmountSold")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSold")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasComputedColumnSql("GetUtcDate()");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("SaleId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Order", b =>
                {
                    b.HasOne("EntityFramework_DesignTables.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.OrderHistory", b =>
                {
                    b.HasOne("EntityFramework_DesignTables.Entities.Customer", "Customer")
                        .WithOne("OrderHistory")
                        .HasForeignKey("EntityFramework_DesignTables.Entities.OrderHistory", "OrderHistoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Product", b =>
                {
                    b.HasOne("EntityFramework_DesignTables.Entities.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityFramework_DesignTables.Entities.ProductList", "ProductList")
                        .WithMany("Products")
                        .HasForeignKey("ProductListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("ProductList");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.ProductList", b =>
                {
                    b.HasOne("EntityFramework_DesignTables.Entities.Inventory", "Inventory")
                        .WithMany("ProductLists")
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Sale", b =>
                {
                    b.HasOne("EntityFramework_DesignTables.Entities.Product", "Product")
                        .WithOne("Sale")
                        .HasForeignKey("EntityFramework_DesignTables.Entities.Sale", "SaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Customer", b =>
                {
                    b.Navigation("OrderHistory");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Inventory", b =>
                {
                    b.Navigation("ProductLists");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.Product", b =>
                {
                    b.Navigation("Sale");
                });

            modelBuilder.Entity("EntityFramework_DesignTables.Entities.ProductList", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
