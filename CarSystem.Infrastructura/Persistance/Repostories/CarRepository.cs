using CarSystem.Aplication.Interfaces;
using CarSystem.Domain.Entities;
using CarSystem.Infrastructura.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarSystem.Infrastructure.Persistence.Repositories;

public class CarRepository : ICarRepository
{
    private readonly MainContext _context;

    public CarRepository(MainContext context)
    {
        _context = context;
    }

    public async Task<int> AddCar(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return car.Id;
    }

    public async Task DeleteCar(Car car)
    {
        _context.Cars.Remove(car);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Car>> GetPagedCars(int pageNumber, int pageSize)
    {
        return await _context.Cars
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetAvailableCars()
    {
        return await _context.Cars
            .Where(c => c.IsAvailable)
            .Include(c => c.Brand)
            .Include(c => c.Dealer)
            .ToListAsync();
    }

    public async Task<Car?> GetCarById(int id)
    {
        return await _context.Cars
            .Include(c => c.Brand)
            .Include(c => c.Dealer)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Car>> GetCarsByBrandId(int brandId)
    {
        return await _context.Cars
            .Where(c => c.BrandId == brandId)
            .Include(c => c.Brand)
            .ToListAsync();
    }

    public async Task<IEnumerable<Car>> GetCarsByDealerId(int dealerId)
    {
        return await _context.Cars
            .Where(c => c.DealerId == dealerId)
            .Include(c => c.Dealer)
            .ToListAsync();
    }

    public async Task UpdateCar(Car car)
    {
        _context.Cars.Update(car);
        await _context.SaveChangesAsync();
    }
}
