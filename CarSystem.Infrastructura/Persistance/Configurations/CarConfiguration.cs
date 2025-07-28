using CarSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSystem.Infrastructura.Persistance.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Brand).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Model).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Year).IsRequired();
        builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
        builder.Property(c => c.Mileage).IsRequired();
        builder.Property(c => c.Color).HasMaxLength(50);
        builder.Property(c => c.FuelType).HasMaxLength(50);
        builder.Property(c => c.Transmission).HasMaxLength(50);
        builder.Property(c => c.Description).HasMaxLength(1000);
        builder.Property(c => c.ImageUrl).HasMaxLength(500);


        builder.HasOne<Dealer>()
               .WithMany()
               .HasForeignKey(c => c.DealerId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Brand>()
               .WithMany()
               .HasForeignKey(c=>c.BrandId) // BrandId bo'lishi kerak
               .OnDelete(DeleteBehavior.Restrict);
    }
}