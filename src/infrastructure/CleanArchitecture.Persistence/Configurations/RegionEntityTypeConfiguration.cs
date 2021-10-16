using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Persistence.Configurations
{
    public class RegionEntityTypeConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
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