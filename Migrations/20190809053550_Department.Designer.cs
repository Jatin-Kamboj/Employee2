﻿// <auto-generated />
using EmployeeManagement.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(EmployeeContext))]
    [Migration("20190809053550_Department")]
    partial class Department
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("EmployeeManagement.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeptName");

                    b.HasKey("DeptId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            DeptId = 1,
                            DeptName = "Hr"
                        },
                        new
                        {
                            DeptId = 2,
                            DeptName = "Payroll"
                        },
                        new
                        {
                            DeptId = 3,
                            DeptName = "IT"
                        });
                });

            modelBuilder.Entity("EmployeeManagement.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Department");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("PhotoPath");

                    b.HasKey("id");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}