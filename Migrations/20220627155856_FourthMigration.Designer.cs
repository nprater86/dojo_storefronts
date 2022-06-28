﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dojo_storefronts.Models;

#nullable disable

namespace dojo_storefronts.Migrations
{
    [DbContext(typeof(MyContext))]
    [Migration("20220627155856_FourthMigration")]
    partial class FourthMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("dojo_storefronts.Models.Cart", b =>
                {
                    b.Property<int>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CartID");

                    b.HasIndex("UserId");

                    b.ToTable("Cart");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expiration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("OwnerUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StorefrontId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductId");

                    b.HasIndex("StorefrontId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("dojo_storefronts.Models.ProductsInCart", b =>
                {
                    b.Property<int>("ProductsInCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ProductsInCartId");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductsInCart");
                });

            modelBuilder.Entity("dojo_storefronts.Models.ProductsInSubmittedOrder", b =>
                {
                    b.Property<int>("ProductsInSubmittedOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("OrderedQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SubmittedOrderId")
                        .HasColumnType("int");

                    b.HasKey("ProductsInSubmittedOrderId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SubmittedOrderId");

                    b.ToTable("ProductsInSubmittedOrders");
                });

            modelBuilder.Entity("dojo_storefronts.Models.ShippingAddress", b =>
                {
                    b.Property<int>("ShippingAddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Address2")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NameOnPackage")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.Property<int>("Zipcode")
                        .HasColumnType("int");

                    b.HasKey("ShippingAddressId");

                    b.HasIndex("UserId1");

                    b.ToTable("ShippingAddresses");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Storefront", b =>
                {
                    b.Property<int>("StorefrontId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("StorefrontId");

                    b.ToTable("Storefronts");
                });

            modelBuilder.Entity("dojo_storefronts.Models.SubmittedOrder", b =>
                {
                    b.Property<int>("SubmittedOrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("ShippingAddressId")
                        .HasColumnType("int");

                    b.Property<int>("StorefrontId")
                        .HasColumnType("int");

                    b.Property<int?>("SubmitterUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SubmittedOrderId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("ShippingAddressId");

                    b.HasIndex("StorefrontId");

                    b.HasIndex("SubmitterUserId");

                    b.ToTable("SubmittedOrders");
                });

            modelBuilder.Entity("dojo_storefronts.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StorefrontId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("StorefrontId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Cart", b =>
                {
                    b.HasOne("dojo_storefronts.Models.User", "Owner")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Payment", b =>
                {
                    b.HasOne("dojo_storefronts.Models.User", "Owner")
                        .WithMany("UserPayments")
                        .HasForeignKey("OwnerUserId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Product", b =>
                {
                    b.HasOne("dojo_storefronts.Models.Storefront", "HomeStorefront")
                        .WithMany("Inventory")
                        .HasForeignKey("StorefrontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HomeStorefront");
                });

            modelBuilder.Entity("dojo_storefronts.Models.ProductsInCart", b =>
                {
                    b.HasOne("dojo_storefronts.Models.Cart", "Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dojo_storefronts.Models.Product", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("dojo_storefronts.Models.ProductsInSubmittedOrder", b =>
                {
                    b.HasOne("dojo_storefronts.Models.Product", "Product")
                        .WithMany("SubmittedOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dojo_storefronts.Models.SubmittedOrder", "SubmittedOrder")
                        .WithMany("Products")
                        .HasForeignKey("SubmittedOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SubmittedOrder");
                });

            modelBuilder.Entity("dojo_storefronts.Models.ShippingAddress", b =>
                {
                    b.HasOne("dojo_storefronts.Models.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("dojo_storefronts.Models.SubmittedOrder", b =>
                {
                    b.HasOne("dojo_storefronts.Models.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dojo_storefronts.Models.ShippingAddress", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dojo_storefronts.Models.Storefront", "Storefront")
                        .WithMany("SubmittedOrders")
                        .HasForeignKey("StorefrontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dojo_storefronts.Models.User", "Submitter")
                        .WithMany("SubmittedOrders")
                        .HasForeignKey("SubmitterUserId");

                    b.Navigation("Payment");

                    b.Navigation("ShippingAddress");

                    b.Navigation("Storefront");

                    b.Navigation("Submitter");
                });

            modelBuilder.Entity("dojo_storefronts.Models.User", b =>
                {
                    b.HasOne("dojo_storefronts.Models.Storefront", "UserStorefront")
                        .WithOne("Owner")
                        .HasForeignKey("dojo_storefronts.Models.User", "StorefrontId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStorefront");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Cart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("SubmittedOrders");
                });

            modelBuilder.Entity("dojo_storefronts.Models.Storefront", b =>
                {
                    b.Navigation("Inventory");

                    b.Navigation("Owner");

                    b.Navigation("SubmittedOrders");
                });

            modelBuilder.Entity("dojo_storefronts.Models.SubmittedOrder", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("dojo_storefronts.Models.User", b =>
                {
                    b.Navigation("SubmittedOrders");

                    b.Navigation("UserAddresses");

                    b.Navigation("UserPayments");
                });
#pragma warning restore 612, 618
        }
    }
}
