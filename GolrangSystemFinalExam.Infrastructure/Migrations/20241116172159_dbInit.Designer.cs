﻿// <auto-generated />
using System;
using GolrangSystemFinalExam.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GolrangSystemFinalExam.Infrastructure.Migrations
{
    [DbContext(typeof(GolrangSystemFinalExamDbContext))]
    [Migration("20241116172159_dbInit")]
    partial class dbInit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiscountType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PreInvoiceDetailId")
                        .HasColumnType("int");

                    b.Property<int?>("PreInvoiceDetailsId")
                        .HasColumnType("int");

                    b.Property<int>("PreInvoiceHeaderId")
                        .HasColumnType("int");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PreInvoiceDetailsId");

                    b.HasIndex("PreInvoiceHeaderId");

                    b.ToTable("Discounts", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PreInvoiceHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PreInvoiceHeaderId");

                    b.HasIndex("ProductId");

                    b.ToTable("PreInvoiceDetails", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SellLineId")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SellLineId");

                    b.HasIndex("SellerId");

                    b.ToTable("PreInvoiceHeaders", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.SellLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SellLines", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.SellLineProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SellLineId")
                        .HasColumnType("int");

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId", "SellLineId");

                    b.HasIndex("SellLineId");

                    b.ToTable("SellLinesProducts", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.SellLinesSellers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SellLineId")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SellLineId");

                    b.HasIndex("SellerId");

                    b.ToTable("SellLinesSellers", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AutorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<DateTime?>("ModifyDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sellers", (string)null);
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Discount", b =>
                {
                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceDetails", "PreInvoiceDetails")
                        .WithMany()
                        .HasForeignKey("PreInvoiceDetailsId");

                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceHeader", "PreInvoiceHeader")
                        .WithMany()
                        .HasForeignKey("PreInvoiceHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreInvoiceDetails");

                    b.Navigation("PreInvoiceHeader");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceDetails", b =>
                {
                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceHeader", "PreInvoiceHeader")
                        .WithMany("PreInvoiceDetails")
                        .HasForeignKey("PreInvoiceHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.Product", "Product")
                        .WithMany("PreInvoiceDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PreInvoiceHeader");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceHeader", b =>
                {
                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.Customer", "Customer")
                        .WithMany("PreInvoiceHeaders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.SellLine", "SellLine")
                        .WithMany("PreInvoiceHeaders")
                        .HasForeignKey("SellLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.Seller", "Seller")
                        .WithMany("PreInvoiceHeaders")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("SellLine");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.SellLineProduct", b =>
                {
                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.Product", "Product")
                        .WithMany("SellLineProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.SellLine", "SellLine")
                        .WithMany("SellLineProducts")
                        .HasForeignKey("SellLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SellLine");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.SellLinesSellers", b =>
                {
                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.SellLine", "SellLine")
                        .WithMany("SellLinesSellers")
                        .HasForeignKey("SellLineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GolrangSystemFinalExam.Infrastructure.Entities.Seller", "Seller")
                        .WithMany("SellLinesSellers")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SellLine");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Customer", b =>
                {
                    b.Navigation("PreInvoiceHeaders");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.PreInvoiceHeader", b =>
                {
                    b.Navigation("PreInvoiceDetails");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Product", b =>
                {
                    b.Navigation("PreInvoiceDetails");

                    b.Navigation("SellLineProducts");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.SellLine", b =>
                {
                    b.Navigation("PreInvoiceHeaders");

                    b.Navigation("SellLineProducts");

                    b.Navigation("SellLinesSellers");
                });

            modelBuilder.Entity("GolrangSystemFinalExam.Infrastructure.Entities.Seller", b =>
                {
                    b.Navigation("PreInvoiceHeaders");

                    b.Navigation("SellLinesSellers");
                });
#pragma warning restore 612, 618
        }
    }
}
