using CarSystem.Aplication.Interfaces;
using CarSystem.Domain.Entities;
using CarSystem.Infrastructura.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CarSystem.Infrastructure.Persistence.Repositories;

public class DealerRepository : IDealerRepository
{
    private readonly MainContext _context;

    public DealerRepository(MainContext context)
    {
        _context = context;
    }

    public async Task<int> AddDealerAsync(Dealer dealer)
    {
        _context.Dealers.Add(dealer);
        await _context.SaveChangesAsync();
        return dealer.Id;
    }

    public async Task DeleteDealerAsync(int id)
    {
        var dealer = await _context.Dealers.FindAsync(id);
        if (dealer is not null)
        {
            _context.Dealers.Remove(dealer);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Dealer>> GetPagedDealers(int pageNumber, int pageSize)
    {
        return await _context.Dealers
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<Dealer?> GetDealerByIdAsync(int id)
    {
        return await _context.Dealers
            .Include(d => d.City)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<Dealer>> GetDealersByCityIdAsync(int cityId)
    {
        return await _context.Dealers
            .Where(d => d.CityId == cityId)
            .Include(d => d.City)
            .ToListAsync();
    }

    public async Task UpdateDealerAsync(Dealer dealer)
    {
        _context.Dealers.Update(dealer);
        await _context.SaveChangesAsync();
    }
}
