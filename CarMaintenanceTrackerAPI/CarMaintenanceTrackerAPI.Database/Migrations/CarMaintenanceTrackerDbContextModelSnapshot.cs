﻿// <auto-generated />
using System;
using CarMaintenanceTracker.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarMaintenanceTrackerAPI.Database.Migrations
{
    [DbContext(typeof(CarMaintenanceTrackerDbContext))]
    partial class CarMaintenanceTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.CarServiceCenter", b =>
                {
                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceCenterId")
                        .HasColumnType("int");

                    b.HasKey("CarId", "ServiceCenterId");

                    b.HasIndex("ServiceCenterId");

                    b.ToTable("CarServiceCenters");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.MaintenanceRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("MaintenanceType")
                        .HasColumnType("int");

                    b.Property<int>("ServiceCenterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("ServiceCenterId");

                    b.ToTable("MaintenanceRecords");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.ServiceCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("ServiceCenters");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.Car", b =>
                {
                    b.HasOne("CarMaintenanceTracker.Database.Entities.User", "User")
                        .WithOne("Car")
                        .HasForeignKey("CarMaintenanceTracker.Database.Entities.Car", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.CarServiceCenter", b =>
                {
                    b.HasOne("CarMaintenanceTracker.Database.Entities.Car", "Car")
                        .WithMany("CarServiceCenters")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarMaintenanceTracker.Database.Entities.ServiceCenter", "ServiceCenter")
                        .WithMany("CarServiceCenters")
                        .HasForeignKey("ServiceCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("ServiceCenter");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.MaintenanceRecord", b =>
                {
                    b.HasOne("CarMaintenanceTracker.Database.Entities.Car", "Car")
                        .WithMany("MaintenanceRecords")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarMaintenanceTracker.Database.Entities.ServiceCenter", "ServiceCenter")
                        .WithMany("MaintenanceRecords")
                        .HasForeignKey("ServiceCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("ServiceCenter");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.Car", b =>
                {
                    b.Navigation("CarServiceCenters");

                    b.Navigation("MaintenanceRecords");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.ServiceCenter", b =>
                {
                    b.Navigation("CarServiceCenters");

                    b.Navigation("MaintenanceRecords");
                });

            modelBuilder.Entity("CarMaintenanceTracker.Database.Entities.User", b =>
                {
                    b.Navigation("Car");
                });
#pragma warning restore 612, 618
        }
    }
}
