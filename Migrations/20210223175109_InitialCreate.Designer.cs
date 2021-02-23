﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Saidality.Models;

namespace Saidality.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210223175109_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Saidality.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MedicineID");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasColumnName("BrandName");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Price")
                        .HasMaxLength(50)
                        .HasColumnType("double")
                        .HasColumnName("Price");

                    b.Property<string>("ScientificName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasColumnName("ScientificName");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasColumnName("Type");

                    b.HasKey("MedicineID");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("Saidality.Models.Pharmcy", b =>
                {
                    b.Property<int>("PharmcyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PharmcyID");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasColumnName("Location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasColumnName("Name");

                    b.HasKey("PharmcyID");

                    b.ToTable("Pharmcys");
                });

            modelBuilder.Entity("Saidality.Models.Stock", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StockID");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("LastUpdateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("MedicieneId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasColumnName("Name");

                    b.Property<int>("PharmacyId")
                        .HasColumnType("int");

                    b.HasKey("StockID");

                    b.HasIndex("MedicieneId");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Saidality.Models.Stock", b =>
                {
                    b.HasOne("Saidality.Models.Medicine", "Mediciene")
                        .WithMany()
                        .HasForeignKey("MedicieneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Saidality.Models.Pharmcy", "Pharmcy")
                        .WithMany("Stocks")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mediciene");

                    b.Navigation("Pharmcy");
                });

            modelBuilder.Entity("Saidality.Models.Pharmcy", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
