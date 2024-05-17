﻿// <auto-generated />
using System;
using BulkInsert.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BulkInsert.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BulkInsert.Context.ElectricityBill", b =>
                {
                    b.Property<long>("BillId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("BillId"));

                    b.Property<DateTime>("BillingPeriodEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BillingPeriodStart")
                        .HasColumnType("datetime2");

                    b.Property<long>("CustomerID")
                        .HasColumnType("bigint");

                    b.Property<decimal>("TotalUsageKWh")
                        .HasColumnType("decimal(18,3)");

                    b.HasKey("BillId");

                    b.ToTable("ElectricityBills", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
