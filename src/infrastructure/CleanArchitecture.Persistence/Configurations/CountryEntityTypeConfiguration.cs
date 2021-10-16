using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class CountryEntityTypeConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
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

            builder.HasMany(prop => prop.CapitalCities)
                .WithOne(prop => prop.Country)
                .HasForeignKey(prop => prop.CountryId);

            builder.OwnsOne(
                o => o.Coordinates,
                sa =>
                {
                    sa.Property(p => p.Latitude).HasColumnName("Latitude");
                    sa.Property(p => p.Longitude).HasColumnName("Longitude");
                });

            builder.OwnsOne(
                o => o.AuditDates,
                sa =>
                {
                    sa.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
                    sa.Property(p => p.ModifiedDate).HasColumnName("ModifiedDate");
                });

            builder.Navigation(o => o.Coordinates)
                .IsRequired();
        }
    }
}