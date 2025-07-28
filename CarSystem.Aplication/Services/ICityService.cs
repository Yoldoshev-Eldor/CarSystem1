using CarSystem.Domain.Entities;

namespace CarSystem.Aplication.Services;

public interface ICityService
{
    Task<City> CreateAsync(City city);
    Task<IEnumerable<City>> GetPagedCities(int pageNumber, int pageSize);
    Task<City?> GetByIdAsync(int id);
    Task<IEnumerable<Dealer>> GetDealersByCityIdAsync(int cityId);
    Task UpdateAsync(City city);
    Task DeleteAsync(int id);
}