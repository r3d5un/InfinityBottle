using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status200OK)]
public class HistoryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<HistoryController> _logger;
    private readonly IMapper _mapper;

    public HistoryController(
        IUnitOfWork unitOfWork,
        ILogger<HistoryController> logger,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<HistoryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var histories = await _unitOfWork.Histories.GetAllAsync();
            var result = _mapper.Map<IEnumerable<HistoryDto>>(histories);
            if (!result.Any())
            {
                return NotFound("No history found");
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(HistoryDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            History? history = await _unitOfWork.Histories.GetAsync(id);
            HistoryDto? result = _mapper.Map<HistoryDto>(history);
            if (result == null)
            {
                return NotFound("History not found");
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
    [ProducesResponseType(typeof(HistoryDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] HistoryDto historyDto)
    {
        try
        {
            var history = _mapper.Map<History>(historyDto);
            await _unitOfWork.Histories.AddAsync(history);
            await _unitOfWork.CompleteAsync();
            var createdHistory = _mapper.Map<HistoryDto>(history);
            return Created("Hisotry added", createdHistory);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut]
    [ProducesResponseType(typeof(HistoryDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] HistoryDto historyDto)
    {
        try
        {
            var history = await _unitOfWork.Histories.GetAsync(id);
            _mapper.Map(historyDto, history);
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
    [ProducesResponseType(typeof(HistoryDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            History? historyToDelete = await _unitOfWork.Histories.GetAsync(id);
            if (historyToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.Histories.RemoveAsync(historyToDelete);
            await _unitOfWork.CompleteAsync();
            return Ok(historyToDelete);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}
