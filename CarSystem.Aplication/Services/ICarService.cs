using CarSystem.Aplication.Dtos;
using CarSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSystem.Aplication.Services;

public interface ICarService
{
    Task<int> AddCar(CarCreateDto car);
    Task UpdateCar(CarDto car);
    Task DeleteCar(CarDto car);
    Task<CarDto?> GetCarById(int id);
    Task<IEnumerable<CarDto>> GetPagedCars(int pageNumber, int pageSize);
    Task<IEnumerable<CarDto>> GetCarsByBrandId(int brandId);
    Task<IEnumerable<CarDto>> GetCarsByDealerId(int dealerId);
    Task<IEnumerable<CarDto>> GetAvailableCars();
}
