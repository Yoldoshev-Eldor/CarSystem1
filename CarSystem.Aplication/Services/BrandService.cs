using CarSystem.Aplication.Dtos;
using CarSystem.Aplication.Interfaces;
using CarSystem.Domain.Entities;

namespace CarSystem.Aplication.Services;

public class BrandService : IBrandService
{
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<int> AddBrandAsync(BrandCreateDto brandDto)
    {
        var brand = new Brand
        {
            Name = brandDto.Name,
            Country = brandDto.Country
        };

        return await _brandRepository.AddBrandAsync(brand);
    }

    public async Task DeleteBrandAsync(int id)
    {
        await _brandRepository.DeleteBrandAsync(id);
    }

    public async Task<BrandDto?> GetBrandByIdAsync(int id)
    {
        var brand = await _brandRepository.GetBrandByIdAsync(id);
        if (brand is null) return null;

        return new BrandDto
        {
            Id = brand.Id,
            Name = brand.Name,
            Country = brand.Country
        };
    }

    public async Task<IEnumerable<BrandDto>> GetBrandsByCountryAsync(string country)
    {
        var brands = await _brandRepository.GetBrandsByCountryAsync(country);

        return brands.Select(b => new BrandDto
        {
            Id = b.Id,
            Name = b.Name,
            Country = b.Country
        });
    }

    public async Task<IEnumerable<BrandDto>> GetBrandsByNameAsync(string name)
    {
        var brands = await _brandRepository.GetBrandsByNameAsync(name);

        return brands.Select(b => new BrandDto
        {
            Id = b.Id,
            Name = b.Name,
            Country = b.Country
        });
    }

    public async Task<IEnumerable<Car>> GetCarsByBrandIdAsync(int brandId)
    {
        return await _brandRepository.GetCarsByBrandIdAsync(brandId);
    }

    public async Task<IEnumerable<BrandDto>> GetPagedBrans(int pageNumber, int pageSize)
    {
        var allBrands = await _brandRepository.GetPagedBrans(int pageNumber, int pageSize);

        return allBrands
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(b => new BrandDto
            {
                Id = b.Id,
                Name = b.Name,
                Country = b.Country
            });
    }

    public async Task UpdateBrandAsync(BrandDto brandDto)
    {
        var brand = new Brand
        {
            Id = brandDto.Id,
            Name = brandDto.Name,
            Country = brandDto.Country
        };

        await _brandRepository.UpdateBrandAsync(brand);
    }
}
