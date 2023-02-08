using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class InfinityBottleController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<InfinityBottleController> _logger;
    private readonly IMapper _mapper;

    public InfinityBottleController(
        IUnitOfWork unitOfWork,
        ILogger<InfinityBottleController> logger,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<InfinityBottleDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var infinityBottles = await _unitOfWork.InfinityBottles.GetAllAsync();
            var result = _mapper.Map<IEnumerable<InfinityBottleDto>>(infinityBottles);
            if (!result.Any())
            {
                return NotFound("No infinity bottles found");
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
    [ProducesResponseType(typeof(InfinityBottleDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var infinityBottle = await _unitOfWork.InfinityBottles.GetAsync(id);
            var result = _mapper.Map<InfinityBottleDto>(infinityBottle);
            if (result == null)
            {
                return NotFound("No infinity bottle found");
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
    [ProducesResponseType(typeof(InfinityBottleDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] InfinityBottleDto infinityBottleDto)
    {
        try
        {
            var infinityBottle = _mapper.Map<InfinityBottle>(infinityBottleDto);
            await _unitOfWork.InfinityBottles.AddAsync(infinityBottle);
            await _unitOfWork.CompleteAsync();
            var createdInfinityBottle = _mapper.Map<InfinityBottleDto>(infinityBottle);
            return Created("InfinityBottle created", createdInfinityBottle);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(InfinityBottleDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] InfinityBottleDto infinitybottleDto)
    {
        try
        {
            var infinityBottle = await _unitOfWork.InfinityBottles.GetAsync(id);
            _mapper.Map(infinitybottleDto, infinityBottle);
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
    [ProducesResponseType(typeof(InfinityBottleDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            InfinityBottle? infinityBottleToDelete = await _unitOfWork.InfinityBottles.GetAsync(id);
            if (infinityBottleToDelete == null)
            {
                return NotFound("No infinity bottle found");
            }

            _unitOfWork.InfinityBottles.RemoveAsync(infinityBottleToDelete);
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
