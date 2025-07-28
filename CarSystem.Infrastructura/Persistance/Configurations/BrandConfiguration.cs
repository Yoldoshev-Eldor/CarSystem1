using CarSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSystem.Infrastructura.Persistance.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
        builder.Property(b => b.Country).HasMaxLength(100);
        builder.Property(b => b.LogoUrl).HasMaxLength(500);
        builder.Property(b => b.Description).HasMaxLength(1000);
    }
}


