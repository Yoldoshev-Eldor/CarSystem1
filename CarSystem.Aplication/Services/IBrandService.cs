using CarSystem.Aplication.Dtos;
using CarSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Aplication.Services;

public interface IBrandService
{
    Task<int> AddBrandAsync(BrandCreateDto brand);
    Task UpdateBrandAsync(BrandDto brand);
    Task DeleteBrandAsync(int id);
    Task<BrandDto?> GetBrandByIdAsync(int id);
    Task<IEnumerable<BrandDto>> GetPagedBrans(int pageNumber, int pageSize);
    Task<IEnumerable<BrandDto>> GetBrandsByCountryAsync(string country);
    Task<IEnumerable<BrandDto>> GetBrandsByNameAsync(string name);
    Task<IEnumerable<Car>> GetCarsByBrandIdAsync(int brandId);
}
