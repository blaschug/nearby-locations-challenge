﻿// <auto-generated />
using System;
using Locations.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Locations.Infrastructure.Migrations
{
    [DbContext(typeof(LocationsDbContext))]
    [Migration("20230321183044_AddLocationSearces")]
    partial class AddLocationSearces
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Locations.Domain.LocationsSearches.Entities.LocationInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LocationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationSearchResponseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationSearchResponseId");

                    b.ToTable("LocationInfo");
                });

            modelBuilder.Entity("Locations.Domain.LocationsSearches.Entities.LocationSearchRequest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocationSearchRequest");
                });

            modelBuilder.Entity("Locations.Domain.LocationsSearches.Entities.LocationSearchResponse", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryFilteredBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LocationSearchResponse");
                });

            modelBuilder.Entity("Locations.Domain.LocationsSearches.LocationSearch", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResponseId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.HasIndex("ResponseId");

                    b.ToTable("LocationSearches");
                });

            modelBuilder.Entity("Locations.Domain.LocationsSearches.Entities.LocationInfo", b =>
                {
                    b.HasOne("Locations.Domain.LocationsSearches.Entities.LocationSearchResponse", null)
                        .WithMany("NearLocations")
                        .HasForeignKey("LocationSearchResponseId");

                    b.OwnsOne("Locations.Domain.LocationsSearches.ValueObjects.Coordinates", "Coordinates", b1 =>
                        {
                            b1.Property<string>("LocationInfoId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("LocationInfoId");

                            b1.ToTable("LocationInfo");

                            b1.WithOwner()
                                .HasForeignKey("LocationInfoId");
                        });

                    b.Navigation("Coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("Locations.Domain.LocationsSearches.Entities.LocationSearchRequest", b =>
                {
                    b.OwnsOne("Locations.Domain.LocationsSearches.ValueObjects.Coordinates", "Coordinates", b1 =>
                        {
                            b1.Property<string>("LocationSearchRequestId")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float");

                            b1.HasKey("LocationSearchRequestId");

                            b1.ToTable("LocationSearchRequest");

                            b1.WithOwner()
                                .HasForeignKey("LocationSearchRequestId");
                        });

                    b.Navigation("Coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("Locations.Domain.LocationsSearches.LocationSearch", b =>
                {
                    b.HasOne("Locations.Domain.LocationsSearches.Entities.LocationSearchRequest", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId");

                    b.HasOne("Locations.Domain.LocationsSearches.Entities.LocationSearchResponse", "Response")
                        .WithMany()
                        .HasForeignKey("ResponseId");

                    b.Navigation("Request");

                    b.Navigation("Response");
                });

            modelBuilder.Entity("Locations.Domain.LocationsSearches.Entities.LocationSearchResponse", b =>
                {
                    b.Navigation("NearLocations");
                });
#pragma warning restore 612, 618
        }
    }
}
