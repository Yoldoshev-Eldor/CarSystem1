using CarSystem.Aplication.Dtos;
using CarSystem.Aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarSystem.Api.Controllers;

[Route("api/brand")]
[ApiController]
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;

    public BrandController(IBrandService brandService)
    {
        _brandService = brandService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] BrandCreateDto dto)
    {
        var id = await _brandService.AddBrandAsync(dto);
        return Ok(new { Id = id });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var brand = await _brandService.GetBrandByIdAsync(id);
        if (brand == null) return NotFound();

        return Ok(brand);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var brands = await _brandService.GetPagedBrans(page, pageSize);
        return Ok(brands);
    }

    [HttpGet("by-country")]
    public async Task<IActionResult> GetByCountry([FromQuery] string country)
    {
        var brands = await _brandService.GetBrandsByCountryAsync(country);
        return Ok(brands);
    }

    [HttpGet("by-name")]
    public async Task<IActionResult> GetByName([FromQuery] string name)
    {
        var brands = await _brandService.GetBrandsByNameAsync(name);
        return Ok(brands);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] BrandDto dto)
    {
        await _brandService.UpdateBrandAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _brandService.DeleteBrandAsync(id);
        return NoContent();
    }
}
