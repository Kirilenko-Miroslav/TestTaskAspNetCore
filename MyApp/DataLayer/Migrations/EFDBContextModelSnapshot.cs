﻿// <auto-generated />
using System;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(EFDBContext))]
    partial class EFDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Entityes.Data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Cloudy")
                        .HasColumnType("float");

                    b.Property<string>("Conditions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double?>("H")
                        .HasColumnType("float");

                    b.Property<double?>("Humidity")
                        .HasColumnType("float");

                    b.Property<double?>("Pressure")
                        .HasColumnType("float");

                    b.Property<double?>("T")
                        .HasColumnType("float");

                    b.Property<double?>("Td")
                        .HasColumnType("float");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("VV")
                        .HasColumnType("float");

                    b.Property<string>("WindDir")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("WindSpeed")
                        .HasColumnType("float");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Data");
                });
#pragma warning restore 612, 618
        }
    }
}
