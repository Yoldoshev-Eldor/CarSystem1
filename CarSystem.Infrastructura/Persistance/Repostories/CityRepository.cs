using CarSystem.Aplication.Interfaces;
using CarSystem.Domain.Entities;
using CarSystem.Infrastructura.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarSystem.Infrastructure.Persistence.Repositories;

public class CityRepository : ICityRepository
{
    private readonly MainContext _context;

    public CityRepository(MainContext context)
    {
        _context = context;
    }

    public async Task<City> CreateAsync(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return city;
    }

    public async Task DeleteAsync(int id)
    {
        var city = await _context.Cities.FindAsync(id);
        if (city is not null)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<City>> GetPagedCities(int pageNumber, int pageSize)
    {
        return await _context.Cities
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<City?> GetByIdAsync(int id)
    {
        return await _context.Cities.FindAsync(id);
    }

    public async Task<IEnumerable<Dealer>> GetDealersByCityIdAsync(int cityId)
    {
        return await _context.Dealers
            .Where(d => d.CityId == cityId)
            .ToListAsync();
    }

    public async Task UpdateAsync(City city)
    {
        _context.Cities.Update(city);
        await _context.SaveChangesAsync();
    }
}
