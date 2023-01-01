using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class BrandController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BrandController> _logger;
    private readonly IMapper _mapper;

    public BrandController(IUnitOfWork unitOfWork, ILogger<BrandController> logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<BrandDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var brands = await _unitOfWork.Brands.GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandDto>>(brands);
            if (!result.Any())
            {
                return NotFound("No brands found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BrandDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var brand = await _unitOfWork.Brands.GetAsync(id);
            var result = _mapper.Map<BrandDto>(brand);
            if (result == null)
            {
                return NotFound("Brand not found");
            }
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(BrandGetDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] BrandPostDto brandDto)
    {
        try
        {
            var brand = _mapper.Map<Brand>(brandDto);
            await _unitOfWork.Brands.AddAsync(brand);
            await _unitOfWork.CompleteAsync();
            var createdBrand = _mapper.Map<BrandDto>(brand);
            return Created("Brand created", createdBrand);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(BrandGetDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] BrandPostDto brandDto)
    {
        try
        {
            var brand = await _unitOfWork.Brands.GetAsync(id);
            _mapper.Map(brandDto, brand);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(BrandDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Brand? brandToDelete = await _unitOfWork.Brands.GetAsync(id);
            if (brandToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.Brands.RemoveAsync(brandToDelete);
            await _unitOfWork.CompleteAsync();
            return Ok(brandToDelete);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}
