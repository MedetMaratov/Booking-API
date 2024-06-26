﻿// <auto-generated />
using System;
using Booking_API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Booking_API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AmenityRoomType", b =>
                {
                    b.Property<Guid>("AmenitiesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomTypesId")
                        .HasColumnType("uuid");

                    b.HasKey("AmenitiesId", "RoomTypesId");

                    b.HasIndex("RoomTypesId");

                    b.ToTable("AmenityRoomType");
                });

            modelBuilder.Entity("Booking_API.Models.Amenity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Amenities");
                });

            modelBuilder.Entity("Booking_API.Models.HotelBranch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("HotelBranches");
                });

            modelBuilder.Entity("Booking_API.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Booking_API.Models.OccupiedRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("CheckOut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ReservationId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ReservationId");

                    b.HasIndex("RoomId");

                    b.ToTable("OccupiedRooms");
                });

            modelBuilder.Entity("Booking_API.Models.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DateIn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateOut")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("HotelBranchId")
                        .HasColumnType("uuid");

                    b.Property<int>("MadeBy")
                        .HasColumnType("integer");

                    b.Property<Guid>("ReservationCreatorId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("HotelBranchId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Booking_API.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("HotelBranchId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsDisabled")
                        .HasColumnType("boolean");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("HotelBranchId");

                    b.HasIndex("TypeId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Booking_API.Models.RoomType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<int>("MaxCapacity")
                        .HasColumnType("integer");

                    b.Property<decimal>("NightlyRate")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RoomsTypes");
                });

            modelBuilder.Entity("AmenityRoomType", b =>
                {
                    b.HasOne("Booking_API.Models.Amenity", null)
                        .WithMany()
                        .HasForeignKey("AmenitiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking_API.Models.RoomType", null)
                        .WithMany()
                        .HasForeignKey("RoomTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Booking_API.Models.HotelBranch", b =>
                {
                    b.HasOne("Booking_API.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("Booking_API.Models.OccupiedRoom", b =>
                {
                    b.HasOne("Booking_API.Models.Reservation", "Reservation")
                        .WithMany("OccupiedRooms")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking_API.Models.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomId");

                    b.Navigation("Reservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Booking_API.Models.Reservation", b =>
                {
                    b.HasOne("Booking_API.Models.HotelBranch", "HotelBranch")
                        .WithMany()
                        .HasForeignKey("HotelBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelBranch");
                });

            modelBuilder.Entity("Booking_API.Models.Room", b =>
                {
                    b.HasOne("Booking_API.Models.HotelBranch", "HotelBranch")
                        .WithMany()
                        .HasForeignKey("HotelBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Booking_API.Models.RoomType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelBranch");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Booking_API.Models.Reservation", b =>
                {
                    b.Navigation("OccupiedRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
