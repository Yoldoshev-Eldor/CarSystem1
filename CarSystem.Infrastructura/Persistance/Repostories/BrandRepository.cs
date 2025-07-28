using CarSystem.Aplication.Interfaces;
using CarSystem.Domain.Entities;
using CarSystem.Infrastructura.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarSystem.Infrastructure.Persistence.Repositories;

public class BrandRepository : IBrandRepository
{
    private readonly MainContext _context;

    public BrandRepository(MainContext context)
    {
        _context = context;
    }

    public async Task<int> AddBrandAsync(Brand brand)
    {
        _context.Brands.Add(brand);
        await _context.SaveChangesAsync();
        return brand.Id;
    }

    public async Task DeleteBrandAsync(int id)
    {
        var brand = await _context.Brands.FindAsync(id);
        if (brand != null)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Brand>> GetPagedBrans(int pageNumber, int pageSize)
    {
        return await _context.Brands
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Brand?> GetBrandByIdAsync(int id)
    {
        return await _context.Brands.FindAsync(id);
    }

    public async Task<IEnumerable<Brand>> GetBrandsByCountryAsync(string country)
    {
        return await _context.Brands
            .Where(b => b.Country.ToLower() == country.ToLower())
            .ToListAsync();
    }

    public async Task<IEnumerable<Brand>> GetBrandsByNameAsync(string name)
    {
        return await _context.Brands
            .Where(b => b.Name.ToLower().Contains(name.ToLower()))
            .ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetCarsByBrandIdAsync(int brandId)
    {
        return await _context.Cars
            .Where(c => c.BrandId == brandId)
            .ToListAsync();
    }

    public async Task UpdateBrandAsync(Brand brand)
    {
        _context.Brands.Update(brand);
        await _context.SaveChangesAsync();
    }
}
