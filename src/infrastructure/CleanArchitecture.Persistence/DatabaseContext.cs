using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
                
        }

        public DbSet<Continent> Continents { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CapitalCity> CapitalCities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Continent>(builder =>
            {
                builder.ToTable("Continent")
                    .HasKey(prop => prop.Id);

                builder.Property(prop => prop.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                builder.HasIndex(prop => prop.Name)
                    .IsUnique();

                builder.Property(prop => prop.Name)
                    .IsRequired();

                builder.HasMany(prop => prop.Regions)
                    .WithOne(prop => prop.Continent)
                    .HasForeignKey(prop => prop.ContinentId);

                builder.OwnsOne(
                    o => o.Coordinates,
                    sa =>
                    {
                        sa.Property(p => p.Latitude).HasColumnName("Latitude");
                        sa.Property(p => p.Longitude).HasColumnName("Longitude");
                    });

                builder.Navigation(o => o.Coordinates)
                    .IsRequired();
            });

            modelBuilder.Entity<Region>(builder =>
            {
                builder.ToTable("Region")
                    .HasKey(prop => prop.Id);

                builder.HasIndex(prop => prop.Name)
                    .IsUnique();

                builder.Property(prop => prop.Name)
                    .IsRequired();

                builder.Property(prop => prop.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                builder.HasMany(prop => prop.Countries)
                    .WithOne(prop => prop.Region)
                    .HasForeignKey(prop => prop.RegionId);

                builder.OwnsOne(
                    o => o.Coordinates,
                    sa =>
                    {
                        sa.Property(p => p.Latitude).HasColumnName("Latitude");
                        sa.Property(p => p.Longitude).HasColumnName("Longitude");
                    });

                builder.Navigation(o => o.Coordinates)
                    .IsRequired();
            });

            modelBuilder.Entity<Country>(builder =>
            {
                builder.ToTable("Country")
                    .HasKey(prop => prop.Id);

                builder.Property(prop => prop.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                builder.HasIndex(prop => prop.Name)
                    .IsUnique();

                builder.Property(prop => prop.Name)
                    .IsRequired();

                builder.OwnsOne(
                    o => o.Coordinates,
                    sa =>
                    {
                        sa.Property(p => p.Latitude).HasColumnName("Latitude");
                        sa.Property(p => p.Longitude).HasColumnName("Longitude");
                    });

                builder.Navigation(o => o.Coordinates)
                    .IsRequired();
            });

            modelBuilder.Entity<CapitalCity>(builder =>
            {
                builder.ToTable("CapitalCity")
                    .HasKey(x => x.Id);

                builder.Property(prop => prop.Id)
                    .IsRequired()
                    .ValueGeneratedOnAdd();

                builder.HasIndex(prop => prop.Name)
                    .IsUnique();

                builder.Property(prop => prop.Name)
                    .IsRequired();

                builder.HasOne(prop => prop.Country)
                    .WithOne(prop => prop.CapitalCity)
                    .HasForeignKey<Country>(prop => prop.CapitalCityId);

                builder.OwnsOne(
                    o => o.Coordinates,
                    sa =>
                    {
                        sa.Property(p => p.Latitude).HasColumnName("Latitude");
                        sa.Property(p => p.Longitude).HasColumnName("Longitude");
                    });

                builder.Navigation(o => o.Coordinates)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}