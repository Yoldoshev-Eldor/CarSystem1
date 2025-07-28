using CarSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSystem.Infrastructura.Persistance.Configurations;

public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
{
    public void Configure(EntityTypeBuilder<Dealer> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).IsRequired().HasMaxLength(150);
        builder.Property(d => d.Address).HasMaxLength(250);
        builder.Property(d => d.Phone).HasMaxLength(50);
        builder.Property(d => d.Email).HasMaxLength(100);
        builder.Property(d => d.Rating).HasColumnType("decimal(3,2)");

        builder.HasOne<City>()
               .WithMany()
               .HasForeignKey(d => d.CityId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
