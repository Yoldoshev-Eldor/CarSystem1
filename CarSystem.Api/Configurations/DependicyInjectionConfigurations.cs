using CarSystem.Aplication.Interfaces;
using CarSystem.Infrastructure.Persistence.Repositories;

namespace CarSystem.Api.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void Configure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBrandRepository, BrandRepository>();
        builder.Services.AddScoped<ICarRepository, CarRepository>();
        builder.Services.AddScoped<ICityRepository, CityRepository>();
        builder.Services.AddScoped<IDealerRepository, DealerRepository>();  




    }
}
