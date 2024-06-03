﻿// <auto-generated />
using System;
using JDChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JDChallenge.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240603173951_InitializeDatabase")]
    partial class InitializeDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JDChallenge.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 6, 3, 17, 39, 51, 115, DateTimeKind.Utc).AddTicks(4289),
                            Name = "Ana",
                            SurName = "Perez"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 6, 3, 17, 39, 51, 115, DateTimeKind.Utc).AddTicks(4291),
                            Name = "Dario",
                            SurName = "Sanchez"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 6, 3, 17, 39, 51, 115, DateTimeKind.Utc).AddTicks(4293),
                            Name = "Diego",
                            SurName = "Lopez"
                        });
                });

            modelBuilder.Entity("JDChallenge.Domain.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PermissionTypeId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("JDChallenge.Domain.Entities.PermissionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PermissionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created = new DateTime(2024, 6, 3, 17, 39, 51, 115, DateTimeKind.Utc).AddTicks(4185),
                            Description = "Description product.read",
                            Name = "product.read"
                        },
                        new
                        {
                            Id = 2,
                            Created = new DateTime(2024, 6, 3, 17, 39, 51, 115, DateTimeKind.Utc).AddTicks(4186),
                            Description = "Description product.write",
                            Name = "product.write"
                        },
                        new
                        {
                            Id = 3,
                            Created = new DateTime(2024, 6, 3, 17, 39, 51, 115, DateTimeKind.Utc).AddTicks(4188),
                            Description = "Description order.read",
                            Name = "order.read"
                        },
                        new
                        {
                            Id = 4,
                            Created = new DateTime(2024, 6, 3, 17, 39, 51, 115, DateTimeKind.Utc).AddTicks(4189),
                            Description = "Description order.write",
                            Name = "order.write"
                        });
                });

            modelBuilder.Entity("JDChallenge.Domain.Entities.Permission", b =>
                {
                    b.HasOne("JDChallenge.Domain.Entities.Employee", "Employee")
                        .WithMany("Permissions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JDChallenge.Domain.Entities.PermissionType", "PermissionType")
                        .WithMany()
                        .HasForeignKey("PermissionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("PermissionType");
                });

            modelBuilder.Entity("JDChallenge.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Permissions");
                });
#pragma warning restore 612, 618
        }
    }
}
