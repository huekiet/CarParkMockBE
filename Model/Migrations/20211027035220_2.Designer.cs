﻿// <auto-generated />
using System;
using CoreApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoreApp.Model.Migrations
{
    [DbContext(typeof(CarParkDbContext))]
    [Migration("20211027035220_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CoreApp.Model.Entity.BookingOffice", b =>
                {
                    b.Property<long>("OfficeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndContractDeadline")
                        .HasColumnType("date");

                    b.Property<string>("OfficeName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OfficePhone")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("OfficePlace")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long?>("OfficePrice")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartContractDeadline")
                        .HasColumnType("date");

                    b.Property<long>("TripId")
                        .HasColumnType("bigint");

                    b.HasKey("OfficeId");

                    b.HasIndex("TripId");

                    b.ToTable("BookingOffices");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Car", b =>
                {
                    b.Property<string>("LicensePlate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CarColor")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("CarType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("ParkId")
                        .HasColumnType("bigint");

                    b.HasKey("LicensePlate");

                    b.HasIndex("ParkId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Employee", b =>
                {
                    b.Property<long>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeAddress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("EmployeeBirthdate")
                        .HasColumnType("date");

                    b.Property<string>("EmployeeEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeePhone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1L,
                            Account = "admin",
                            Department = "employee",
                            EmployeeAddress = "Hanoi",
                            EmployeeEmail = "admin@carpark.com",
                            EmployeeName = "Admin",
                            EmployeePhone = "0812345567",
                            Password = "AQAAAAEAACcQAAAAEA7LKXg/E5vVTkNJy/lfMcq/h+GaS0patCgHoULIr1UERDTxluxQbyhLF/2F4vTjhg==",
                            Sex = "0"
                        });
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Parkinglot", b =>
                {
                    b.Property<long>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ParkArea")
                        .HasColumnType("bigint");

                    b.Property<string>("ParkName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ParkPlace")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<long>("ParkPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("ParkStatus")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ParkId");

                    b.ToTable("Parkinglots");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Ticket", b =>
                {
                    b.Property<long>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan?>("BookingTime")
                        .HasColumnType("time");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("LicensePlate")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("TripId")
                        .HasColumnType("bigint");

                    b.HasKey("TicketId");

                    b.HasIndex("LicensePlate");

                    b.HasIndex("TripId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Trip", b =>
                {
                    b.Property<long>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookedTicketNumber")
                        .HasColumnType("int");

                    b.Property<string>("CarType")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan?>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<string>("Destination")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Driver")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("MaximumOnlineTicketNumber")
                        .HasColumnType("int");

                    b.HasKey("TripId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.BookingOffice", b =>
                {
                    b.HasOne("CoreApp.Model.Entity.Trip", "Trip")
                        .WithMany("BookingOffices")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Car", b =>
                {
                    b.HasOne("CoreApp.Model.Entity.Parkinglot", "Parkinglot")
                        .WithMany("Cars")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parkinglot");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Ticket", b =>
                {
                    b.HasOne("CoreApp.Model.Entity.Car", "Car")
                        .WithMany("Tickets")
                        .HasForeignKey("LicensePlate");

                    b.HasOne("CoreApp.Model.Entity.Trip", "Trip")
                        .WithMany("Tickets")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Car", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Parkinglot", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CoreApp.Model.Entity.Trip", b =>
                {
                    b.Navigation("BookingOffices");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
