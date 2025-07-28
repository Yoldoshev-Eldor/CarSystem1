using CarSystem.Domain.Entities;

namespace CarSystem.Aplication.Interfaces;

public interface ICarRepository
{
    Task<int> AddCar(Car car);
    Task UpdateCar(Car car);
    Task DeleteCar(Car car);
    Task<Car?> GetCarById(int id);
    Task<IEnumerable<Car>> GetPagedCars(int pageNumber, int pageSize);
    Task<IEnumerable<Car>> GetCarsByBrandId(int brandId);
    Task<IEnumerable<Car>> GetCarsByDealerId(int dealerId);
    Task<IEnumerable<Car>> GetAvailableCars();
}
