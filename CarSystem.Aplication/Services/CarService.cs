using CarSystem.Aplication.Dtos;
using CarSystem.Aplication.Interfaces;
using CarSystem.Aplication.Services;
using CarSystem.Domain.Entities;

namespace CarSystem.Application.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public async Task<int> AddCar(CarCreateDto carDto)
    {
        var car = new Car
        {
            Model = carDto.Model,
            Price = carDto.Price,
            IsAvailable = carDto.IsAvailable,
            BrandId = carDto.BrandId,
            DealerId = carDto.DealerId,
            Year = carDto.Year,
            Color = carDto.Color,
            FuelType = carDto.FuelType,
            Transmission = carDto.Transmission,
            Mileage = carDto.Mileage
        };

        return await _carRepository.AddCar(car);
    }

    public async Task DeleteCar(CarDto carDto)
    {
        var car = new Car
        {
            Id = carDto.Id,
            Model = carDto.Model,
            BrandId = carDto.BrandId,
            DealerId = carDto.DealerId,
            Price = carDto.Price,
            Year = carDto.Year,
            IsAvailable = carDto.IsAvailable,
            Color = carDto.Color,
            FuelType = carDto.FuelType,
            Transmission = carDto.Transmission,
            Mileage = carDto.Mileage
        };

        await _carRepository.DeleteCar(car);
    }

    public async Task<IEnumerable<CarDto>> GetAvailableCars()
    {
        var cars = await _carRepository.GetAvailableCars();
        return cars.Select(ToDto);
    }

    public async Task<CarDto?> GetCarById(int id)
    {
        var car = await _carRepository.GetCarById(id);
        return car is not null ? ToDto(car) : null;
    }

    public async Task<IEnumerable<CarDto>> GetCarsByBrandId(int brandId)
    {
        var cars = await _carRepository.GetCarsByBrandId(brandId);
        return cars.Select(ToDto);
    }

    public async Task<IEnumerable<CarDto>> GetCarsByDealerId(int dealerId)
    {
        var cars = await _carRepository.GetCarsByDealerId(dealerId);
        return cars.Select(ToDto);
    }

    public async Task<IEnumerable<CarDto>> GetPagedCars(int pageNumber, int pageSize)
    {
        var cars = await _carRepository.GetPagedCars(int pageNumber, int pageSize);
        return cars
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(ToDto);
    }

    public async Task UpdateCar(CarDto carDto)
    {
        var car = new Car
        {
            Id = carDto.Id,
            Model = carDto.Model,
            Price = carDto.Price,
            Year = carDto.Year,
            BrandId = carDto.BrandId,
            DealerId = carDto.DealerId,
            IsAvailable = carDto.IsAvailable,
            Color = carDto.Color,
            FuelType = carDto.FuelType,
            Transmission = carDto.Transmission,
            Mileage = carDto.Mileage
        };

        await _carRepository.UpdateCar(car);
    }

    private CarDto ToDto(Car car)
    {
        return new CarDto
        {
            Id = car.Id,
            Model = car.Model,
            Price = car.Price,
            Year = car.Year,
            IsAvailable = car.IsAvailable,
            BrandId = car.BrandId,
            DealerId = car.DealerId,
            Color = car.Color,
            FuelType = car.FuelType,
            Transmission = car.Transmission,
            Mileage = car.Mileage
        };
    }
}
