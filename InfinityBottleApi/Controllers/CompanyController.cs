using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class CompanyController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CompanyController> _logger;
    private readonly IMapper _mapper;

    public CompanyController(
        IUnitOfWork unitOfWork,
        ILogger<CompanyController> logger,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CompanyDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var companies = await _unitOfWork.Companies.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CompanyDto>>(companies);
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
    [ProducesResponseType(typeof(CompanyDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            Company? company = await _unitOfWork.Companies.GetAsync(id);
            CompanyGetDto? result = _mapper.Map<CompanyGetDto>(company);
            if (result == null)
            {
                return NotFound("Company not found");
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
    [ProducesResponseType(typeof(CompanyDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CompanyPostDto countryDto)
    {
        try
        {
            var company = _mapper.Map<Company>(countryDto);
            await _unitOfWork.Companies.AddAsync(company);
            await _unitOfWork.CompleteAsync();
            var createdCompany = _mapper.Map<CompanyDto>(company);
            return Created("Company created", createdCompany);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CompanyDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CompanyPostDto countryDto)
    {
        try
        {
            var company = await _unitOfWork.Companies.GetAsync(id);
            _mapper.Map(countryDto, company);
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
    [ProducesResponseType(typeof(CompanyDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Company? companyToDelete = await _unitOfWork.Companies.GetAsync(id);
            if (companyToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.Companies.RemoveAsync(companyToDelete);
            await _unitOfWork.CompleteAsync();
            return Ok(companyToDelete);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}
