﻿// <auto-generated />
using System;
using Employee.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employee.Data.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20241222155923_EmployeeDataId")]
    partial class EmployeeDataId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employee.Data.EmployeeModel", b =>
                {
                    b.Property<long>("EmployeeDataId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EmployeeDataId"));

                    b.Property<decimal>("Apr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Aug")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Dec")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Feb")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Jan")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Jul")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Jun")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Mar")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("May")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Nov")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Oct")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sep")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("TaxId")
                        .HasColumnType("bigint");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.Property<decimal>("YearlySum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EmployeeDataId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
