using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistence.Configurations;
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
            modelBuilder.ApplyConfiguration(new ContinentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RegionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CapitalCityEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}