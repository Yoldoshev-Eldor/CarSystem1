using CarSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Aplication.Services;

public class CityService : ICityService
{
    public Task<City> CreateAsync(City city)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<City?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Dealer>> GetDealersByCityIdAsync(int cityId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<City>> GetPagedCities(int pageNumber, int pageSize)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(City city)
    {
        throw new NotImplementedException();
    }
}
