﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagementSystem.DAL;

#nullable disable

namespace OrderManagementSystem.DAL.Migrations
{
    [DbContext(typeof(OrderManagementSystemContext))]
    [Migration("20241018224717_initDb")]
    partial class initDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderManagementSystem.Tables.Guide.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("StockQuantity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OwnerId");

                    b.ToTable("Products", "Guide");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.Order.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Orders", "Order");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.Order.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ModifiedBy");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems", "Order");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.People.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Customers", "People");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.People.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AddedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AddedBy");

                    b.HasIndex("DeletedBy");

                    b.HasIndex("ModifiedBy");

                    b.ToTable("Users", "People");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.Guide.Product", b =>
                {
                    b.HasOne("OrderManagementSystem.Tables.People.User", "CreatedUser")
                        .WithMany("ProductCreated")
                        .HasForeignKey("AddedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "DeletedUser")
                        .WithMany("ProductDeleted")
                        .HasForeignKey("DeletedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "ModifiedUser")
                        .WithMany("ProductModified")
                        .HasForeignKey("ModifiedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("ModifiedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.Order.Order", b =>
                {
                    b.HasOne("OrderManagementSystem.Tables.People.User", "CreatedUser")
                        .WithMany("OrderCreated")
                        .HasForeignKey("AddedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderManagementSystem.Tables.People.User", "DeletedUser")
                        .WithMany("OrderDeleted")
                        .HasForeignKey("DeletedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "ModifiedUser")
                        .WithMany("OrderModified")
                        .HasForeignKey("ModifiedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("Customer");

                    b.Navigation("DeletedUser");

                    b.Navigation("ModifiedUser");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.Order.OrderItem", b =>
                {
                    b.HasOne("OrderManagementSystem.Tables.People.User", "CreatedUser")
                        .WithMany("OrderItemCreated")
                        .HasForeignKey("AddedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "DeletedUser")
                        .WithMany("OrderItemDeleted")
                        .HasForeignKey("DeletedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "ModifiedUser")
                        .WithMany("OrderItemModified")
                        .HasForeignKey("ModifiedBy");

                    b.HasOne("OrderManagementSystem.Tables.Order.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderManagementSystem.Tables.Guide.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("ModifiedUser");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.People.Customer", b =>
                {
                    b.HasOne("OrderManagementSystem.Tables.People.User", "CreatedUser")
                        .WithMany("CustomerCreated")
                        .HasForeignKey("AddedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "DeletedUser")
                        .WithMany("CustomerDeleted")
                        .HasForeignKey("DeletedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "ModifiedUser")
                        .WithMany("CustomerModified")
                        .HasForeignKey("ModifiedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("ModifiedUser");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.People.User", b =>
                {
                    b.HasOne("OrderManagementSystem.Tables.People.User", "CreatedUser")
                        .WithMany("UserCreated")
                        .HasForeignKey("AddedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "DeletedUser")
                        .WithMany("UserDeleted")
                        .HasForeignKey("DeletedBy");

                    b.HasOne("OrderManagementSystem.Tables.People.User", "ModifiedUser")
                        .WithMany("UserModified")
                        .HasForeignKey("ModifiedBy");

                    b.Navigation("CreatedUser");

                    b.Navigation("DeletedUser");

                    b.Navigation("ModifiedUser");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.Guide.Product", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.Order.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.People.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderManagementSystem.Tables.People.User", b =>
                {
                    b.Navigation("CustomerCreated");

                    b.Navigation("CustomerDeleted");

                    b.Navigation("CustomerModified");

                    b.Navigation("OrderCreated");

                    b.Navigation("OrderDeleted");

                    b.Navigation("OrderItemCreated");

                    b.Navigation("OrderItemDeleted");

                    b.Navigation("OrderItemModified");

                    b.Navigation("OrderModified");

                    b.Navigation("ProductCreated");

                    b.Navigation("ProductDeleted");

                    b.Navigation("ProductModified");

                    b.Navigation("Products");

                    b.Navigation("UserCreated");

                    b.Navigation("UserDeleted");

                    b.Navigation("UserModified");
                });
#pragma warning restore 612, 618
        }
    }
}
