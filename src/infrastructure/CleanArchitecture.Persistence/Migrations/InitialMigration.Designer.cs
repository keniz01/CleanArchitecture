// <auto-generated />
using System;
using CleanArchitecture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArchitecture.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210923153932_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.CapitalCity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CapitalCity");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Continent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Continent");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<Guid>("CapitalCityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CapitalCityId")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("RegionId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Region", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<Guid>("ContinentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Region");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.CapitalCity", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.Entities.Coordinate", "Coordinates", b1 =>
                        {
                            b1.Property<Guid>("CapitalCityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("CapitalCityId");

                            b1.ToTable("CapitalCity");

                            b1.WithOwner()
                                .HasForeignKey("CapitalCityId");
                        });

                    b.Navigation("Coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Continent", b =>
                {
                    b.OwnsOne("CleanArchitecture.Domain.Entities.Coordinate", "Coordinates", b1 =>
                        {
                            b1.Property<Guid>("ContinentId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("ContinentId");

                            b1.ToTable("Continent");

                            b1.WithOwner()
                                .HasForeignKey("ContinentId");
                        });

                    b.Navigation("Coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Country", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.CapitalCity", "CapitalCity")
                        .WithOne("Country")
                        .HasForeignKey("CleanArchitecture.Domain.Entities.Country", "CapitalCityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CleanArchitecture.Domain.Entities.Region", "Region")
                        .WithMany("Countries")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CleanArchitecture.Domain.Entities.Coordinate", "Coordinates", b1 =>
                        {
                            b1.Property<Guid>("CountryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("CountryId");

                            b1.ToTable("Country");

                            b1.WithOwner()
                                .HasForeignKey("CountryId");
                        });

                    b.Navigation("CapitalCity");

                    b.Navigation("Coordinates")
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Region", b =>
                {
                    b.HasOne("CleanArchitecture.Domain.Entities.Continent", "Continent")
                        .WithMany("Regions")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("CleanArchitecture.Domain.Entities.Coordinate", "Coordinates", b1 =>
                        {
                            b1.Property<Guid>("RegionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Latitude")
                                .HasColumnType("float")
                                .HasColumnName("Latitude");

                            b1.Property<double>("Longitude")
                                .HasColumnType("float")
                                .HasColumnName("Longitude");

                            b1.HasKey("RegionId");

                            b1.ToTable("Region");

                            b1.WithOwner()
                                .HasForeignKey("RegionId");
                        });

                    b.Navigation("Continent");

                    b.Navigation("Coordinates")
                        .IsRequired();
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.CapitalCity", b =>
                {
                    b.Navigation("Country");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Continent", b =>
                {
                    b.Navigation("Regions");
                });

            modelBuilder.Entity("CleanArchitecture.Domain.Entities.Region", b =>
                {
                    b.Navigation("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
