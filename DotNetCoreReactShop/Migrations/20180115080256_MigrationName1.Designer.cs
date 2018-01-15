﻿// <auto-generated />
using DotNetCoreReactShop.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DotNetCoreReactShop.Migrations
{
    [DbContext(typeof(DefaultDbContext))]
    [Migration("20180115080256_MigrationName1")]
    partial class MigrationName1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DotNetCoreReactShop.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("category_ıd");

                    b.Property<string>("CategoryName")
                        .HasColumnName("category_name");

                    b.HasKey("CategoryId")
                        .HasName("pk_categories");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("DotNetCoreReactShop.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ıd");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_contacts");

                    b.ToTable("contacts");
                });

            modelBuilder.Entity("DotNetCoreReactShop.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_ıd");

                    b.Property<string>("City")
                        .HasColumnName("city");

                    b.Property<string>("Email")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Postcode")
                        .HasColumnName("postcode");

                    b.Property<string>("Province")
                        .HasColumnName("province");

                    b.Property<string>("Street")
                        .HasColumnName("street");

                    b.Property<DateTime>("TimeCreate")
                        .HasColumnName("time_create");

                    b.Property<decimal>("TotalValue")
                        .HasColumnName("total_value");

                    b.HasKey("OrderId")
                        .HasName("pk_orders");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("DotNetCoreReactShop.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_ıtem_ıd");

                    b.Property<int>("OrderId")
                        .HasColumnName("order_ıd");

                    b.Property<string>("Pizza")
                        .HasColumnName("pizza");

                    b.Property<decimal>("Price")
                        .HasColumnName("price");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<string>("Size")
                        .HasColumnName("size");

                    b.Property<decimal>("Subtotal")
                        .HasColumnName("subtotal");

                    b.HasKey("OrderItemId")
                        .HasName("pk_order_ıtems");

                    b.HasIndex("OrderId")
                        .HasName("ıx_order_ıtems_order_ıd");

                    b.ToTable("order_ıtems");
                });

            modelBuilder.Entity("DotNetCoreReactShop.Models.Pizza", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("pizza_ıd");

                    b.Property<int?>("CategoryId")
                        .HasColumnName("category_ıd");

                    b.Property<string>("CategoryName")
                        .HasColumnName("category_name");

                    b.Property<string>("Image")
                        .HasColumnName("ımage");

                    b.Property<string>("PizzaName")
                        .HasColumnName("pizza_name");

                    b.Property<string>("PizzaNo")
                        .HasColumnName("pizza_no")
                        .HasMaxLength(6);

                    b.Property<decimal>("Price")
                        .HasColumnName("price");

                    b.HasKey("PizzaId")
                        .HasName("pk_pizzas");

                    b.HasIndex("CategoryId")
                        .HasName("ıx_pizzas_category_ıd");

                    b.ToTable("pizzas");
                });

            modelBuilder.Entity("DotNetCoreReactShop.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ıd");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnName("email_confirmed");

                    b.Property<string>("GivenName")
                        .HasColumnName("given_name");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnName("normalized_email")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnName("normalized_user_name")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasColumnName("user_name")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.HasIndex("NormalizedEmail")
                        .HasName("email_ındex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("user_name_ındex")
                        .HasFilter("[normalized_user_name] IS NOT NULL");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ıd");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnName("normalized_name")
                        .HasMaxLength(256);

                    b.HasKey("Id")
                        .HasName("pk_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("role_name_ındex")
                        .HasFilter("[normalized_name] IS NOT NULL");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ıd");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnName("role_ıd");

                    b.HasKey("Id")
                        .HasName("pk_role_claims");

                    b.HasIndex("RoleId")
                        .HasName("ıx_role_claims_role_ıd");

                    b.ToTable("role_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ıd");

                    b.Property<string>("ClaimType")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_ıd");

                    b.HasKey("Id")
                        .HasName("pk_user_claims");

                    b.HasIndex("UserId")
                        .HasName("ıx_user_claims_user_ıd");

                    b.ToTable("user_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnName("user_ıd");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_user_logins");

                    b.HasIndex("UserId")
                        .HasName("ıx_user_logins_user_ıd");

                    b.ToTable("user_logins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_ıd");

                    b.Property<string>("RoleId")
                        .HasColumnName("role_ıd");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_user_roles");

                    b.HasIndex("RoleId")
                        .HasName("ıx_user_roles_role_ıd");

                    b.ToTable("user_roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnName("user_ıd");

                    b.Property<string>("LoginProvider")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_user_tokens");

                    b.ToTable("user_tokens");
                });

            modelBuilder.Entity("DotNetCoreReactShop.Models.OrderItem", b =>
                {
                    b.HasOne("DotNetCoreReactShop.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_order_ıtems_orders_order_ıd")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DotNetCoreReactShop.Models.Pizza", b =>
                {
                    b.HasOne("DotNetCoreReactShop.Models.Category", "Category")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("fk_pizzas_categories_category_ıd");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_role_claims_roles_role_ıd")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DotNetCoreReactShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_claims_users_user_ıd")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DotNetCoreReactShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_logins_users_user_ıd")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_user_roles_roles_role_ıd")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DotNetCoreReactShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_roles_users_user_ıd")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DotNetCoreReactShop.Models.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_user_tokens_users_user_ıd")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
