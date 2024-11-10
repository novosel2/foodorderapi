﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240309172327_addOrders")]
    partial class addOrders
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Entities.MeatType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MeatTypes");
                });

            modelBuilder.Entity("Core.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateTimeOfOrder")
                        .HasColumnType("datetime2");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Core.Domain.Entities.OrderedItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderedItems");
                });

            modelBuilder.Entity("Core.Domain.Entities.OrderedItemTopping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderedItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToppingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OrderedItemId");

                    b.HasIndex("ToppingId");

                    b.ToTable("OrderedItemToppinngs");
                });

            modelBuilder.Entity("Core.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MeatTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<Guid>("ProductTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("MeatTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Core.Domain.Entities.ProductType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("Core.Domain.Entities.Topping", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("Core.Domain.Entities.ToppingProduct", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ToppingId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductId", "ToppingId");

                    b.HasIndex("ToppingId");

                    b.ToTable("ToppingsProducts");
                });

            modelBuilder.Entity("Core.Domain.Entities.OrderedItem", b =>
                {
                    b.HasOne("Core.Domain.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Core.Domain.Entities.OrderedItemTopping", b =>
                {
                    b.HasOne("Core.Domain.Entities.OrderedItem", "OrderedItem")
                        .WithMany()
                        .HasForeignKey("OrderedItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Entities.Topping", "Topping")
                        .WithMany()
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderedItem");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("Core.Domain.Entities.Product", b =>
                {
                    b.HasOne("Core.Domain.Entities.MeatType", "MeatType")
                        .WithMany()
                        .HasForeignKey("MeatTypeId");

                    b.HasOne("Core.Domain.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MeatType");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("Core.Domain.Entities.Topping", b =>
                {
                    b.HasOne("Core.Domain.Entities.Product", null)
                        .WithMany("Toppings")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Core.Domain.Entities.ToppingProduct", b =>
                {
                    b.HasOne("Core.Domain.Entities.Product", "Product")
                        .WithMany("ToppingProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Entities.Topping", "Topping")
                        .WithMany("ToppingProducts")
                        .HasForeignKey("ToppingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("Core.Domain.Entities.Product", b =>
                {
                    b.Navigation("ToppingProducts");

                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("Core.Domain.Entities.Topping", b =>
                {
                    b.Navigation("ToppingProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
