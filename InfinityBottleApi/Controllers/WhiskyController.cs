using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class WhiskyController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<WhiskyController> _logger;
    private readonly IMapper _mapper;

    public WhiskyController(
        IUnitOfWork unitOfWork,
        ILogger<WhiskyController> logger,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WhiskyDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var whiskies = await _unitOfWork.Whiskies.GetAllAsync();
            var result = _mapper.Map<IEnumerable<WhiskyDto>>(whiskies);
            if (!result.Any())
            {
                return NotFound("No whiskies found");
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
    [ProducesResponseType(typeof(WhiskyDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var whisky = await _unitOfWork.Whiskies.GetAsync(id);
            var result = _mapper.Map<WhiskyDto>(whisky);
            if (result == null)
            {
                return NotFound("Whisky not found");
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
    [ProducesResponseType(typeof(WhiskyDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] WhiskyDto whiskyDto)
    {
        try
        {
            var whisky = _mapper.Map<Whisky>(whiskyDto);
            await _unitOfWork.Whiskies.AddAsync(whisky);
            await _unitOfWork.CompleteAsync();
            var createdWhisky = _mapper.Map<WhiskyDto>(whisky);
            return Created("Whisky created", createdWhisky);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(WhiskyDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] WhiskyDto whiskyDto)
    {
        try
        {
            var whisky = await _unitOfWork.Whiskies.GetAsync(id);
            _mapper.Map(whiskyDto, whisky);
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
    [ProducesResponseType(typeof(WhiskyDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Whisky? whiskyToDelete = await _unitOfWork.Whiskies.GetAsync(id);
            if (whiskyToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.Whiskies.RemoveAsync(whiskyToDelete);
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
