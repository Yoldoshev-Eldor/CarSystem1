using CarSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CarSystem.Infrastructura.Persistance;

public class MainContext :DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Dealer> Dealers { get; set; }

    public MainContext(DbContextOptions<MainContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
