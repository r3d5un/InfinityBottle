using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class CountryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CountryController> _logger;
    private readonly IMapper _mapper;

    public CountryController(
        IUnitOfWork unitOfWork,
        ILogger<CountryController> logger,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CountryDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var countries = await _unitOfWork.Countries.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CountryDto>>(countries);
            if (!result.Any())
            {
                return NotFound("No countries found");
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
    [ProducesResponseType(typeof(CountryDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            var country = await _unitOfWork.Countries.GetAsync(id);
            var result = _mapper.Map<CountryDto>(country);
            if (result == null)
            {
                return NotFound("Country not found");
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
    [ProducesResponseType(typeof(CountryDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CountryDto countryDto)
    {
        try
        {
            var country = _mapper.Map<Country>(countryDto);
            await _unitOfWork.Countries.AddAsync(country);
            await _unitOfWork.CompleteAsync();
            return Created("Country created", country);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CountryDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(string id, [FromBody] CountryDto countryDto)
    {
        try
        {
            var country = await _unitOfWork.Countries.GetAsync(id);
            _mapper.Map(countryDto, country);
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
    [ProducesResponseType(typeof(CountryDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            Country? countryToDelete = await _unitOfWork.Countries.GetAsync(id);
            if (countryToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.Countries.RemoveAsync(countryToDelete);
            await _unitOfWork.CompleteAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}
