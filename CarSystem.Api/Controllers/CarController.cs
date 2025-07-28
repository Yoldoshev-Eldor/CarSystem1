using CarSystem.Aplication.Dtos;
using CarSystem.Aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarSystem.Api.Controllers
{
    [Route("api/car")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarCreateDto dto)
        {
            var carId = await _carService.AddCar(dto);
            return Ok(new { Id = carId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var car = await _carService.GetCarById(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailable()
        {
            var cars = await _carService.GetAvailableCars();
            return Ok(cars);
        }

        [HttpGet("brand/{brandId}")]
        public async Task<IActionResult> GetByBrand(int brandId)
        {
            var cars = await _carService.GetCarsByBrandId(brandId);
            return Ok(cars);
        }

        [HttpGet("dealer/{dealerId}")]
        public async Task<IActionResult> GetByDealer(int dealerId)
        {
            var cars = await _carService.GetCarsByDealerId(dealerId);
            return Ok(cars);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var cars = await _carService.GetPagedCars(pageNumber, pageSize);
            return Ok(cars);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] CarDto car)
        {
            await _carService.UpdateCar(car);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCar([FromBody] CarDto car)
        {
            await _carService.DeleteCar(car);
            return NoContent();
        }
    }
}
