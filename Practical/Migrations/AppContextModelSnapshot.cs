﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Practical;

namespace Practical.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Practical.Model.Club", b =>
                {
                    b.Property<char>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");

                    b.HasData(
                        new
                        {
                            ClubId = 'A',
                            Name = "Roadtrip"
                        },
                        new
                        {
                            ClubId = 'B',
                            Name = "Boating"
                        });
                });

            modelBuilder.Entity("Practical.Model.Department", b =>
                {
                    b.Property<char>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("character(1)");

                    b.Property<decimal>("AnnualBudget")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 'm',
                            AnnualBudget = 1000m,
                            Name = "Accounting"
                        },
                        new
                        {
                            DepartmentId = 'n',
                            AnnualBudget = 1200m,
                            Name = "Engineering"
                        });
                });

            modelBuilder.Entity("Practical.Model.Employee", b =>
                {
                    b.Property<int>("EmploeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<char>("ClubId")
                        .HasColumnType("character(1)");

                    b.Property<char?>("DepartmentId")
                        .HasColumnType("character(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("EmploeeId");

                    b.HasIndex("ClubId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmploeeId = 1,
                            ClubId = 'A',
                            DepartmentId = 'm',
                            Name = "Satish"
                        },
                        new
                        {
                            EmploeeId = 2,
                            ClubId = 'B',
                            DepartmentId = 'm',
                            Name = "Hiren"
                        },
                        new
                        {
                            EmploeeId = 3,
                            ClubId = 'A',
                            DepartmentId = 'n',
                            Name = "Naren"
                        },
                        new
                        {
                            EmploeeId = 4,
                            ClubId = 'A',
                            DepartmentId = 'm',
                            Name = "Chris"
                        },
                        new
                        {
                            EmploeeId = 5,
                            ClubId = 'B',
                            DepartmentId = 'n',
                            Name = "Jon"
                        });
                });

            modelBuilder.Entity("Practical.Model.Employee", b =>
                {
                    b.HasOne("Practical.Model.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Practical.Model.Department", "Department")
                        .WithMany("employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
