using AutoMapper;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
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
    public async Task<IActionResult> Get()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        var result = _mapper.Map<IEnumerable<CountryDto>>(countries);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var country = await _unitOfWork.Countries.GetAsync(id);
        var result = _mapper.Map<CountryDto>(country);
        return Ok(result);
    }
}
