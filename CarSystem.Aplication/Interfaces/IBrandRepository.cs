using CarSystem.Domain.Entities;

namespace CarSystem.Aplication.Interfaces;

public interface IBrandRepository
{
    Task<int> AddBrandAsync(Brand brand);
    Task UpdateBrandAsync(Brand brand);
    Task DeleteBrandAsync(int id);
    Task<Brand?> GetBrandByIdAsync(int id);
    Task<IEnumerable<Brand>> GetPagedBrans(int pageNumber, int pageSize);
    Task<IEnumerable<Brand>> GetBrandsByCountryAsync(string country);
    Task<IEnumerable<Brand>> GetBrandsByNameAsync(string name);
    Task<IEnumerable<Car>> GetCarsByBrandIdAsync(int brandId); 
}
