﻿// <auto-generated />
using System;
using Inlämningsuppgift.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inlämningsuppgift.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Inlämningsuppgift.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Namn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pris")
                        .HasColumnType("float");

                    b.Property<string>("beskrivning")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("category_IdId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("category_IdId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Inlämningsuppgift.Data.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Namn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Inlämningsuppgift.Data.Product", b =>
                {
                    b.HasOne("Inlämningsuppgift.Data.ProductCategory", "category_Id")
                        .WithMany()
                        .HasForeignKey("category_IdId");

                    b.Navigation("category_Id");
                });
#pragma warning restore 612, 618
        }
    }
}
