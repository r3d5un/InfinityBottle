using AutoMapper;
using DataAccess.Models;
using InfinityBottleApi.DataTransferObjects.DatabaseObjects;
using InfinityBottleApi.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace InfinityBottleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class CategoryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CategoryController> _logger;
    private readonly IMapper _mapper;

    public CategoryController(
        IUnitOfWork unitOfWork,
        ILogger<CategoryController> logger,
        IMapper mapper
    )
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            if (!result.Any())
            {
                return NotFound("No categories found");
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
    [ProducesResponseType(typeof(CategoryDto), 200)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetAsync(id);
            var result = _mapper.Map<CategoryDto>(category);
            if (result == null)
            {
                return NotFound("Category not found");
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
    [ProducesResponseType(typeof(CategoryGetDto), 201)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromBody] CategoryPostDto categoryDto)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();
            var createdCategory = _mapper.Map<CategoryDto>(category);
            return Created("Category created", createdCategory);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(CategoryGetDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] CategoryPostDto categoryDto)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetAsync(id);
            _mapper.Map(categoryDto, category);
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
    [ProducesResponseType(typeof(CategoryDto), 200)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            Category? categoryToDelete = await _unitOfWork.Categories.GetAsync(id);
            if (categoryToDelete is null)
            {
                return NotFound();
            }

            _unitOfWork.Categories.RemoveAsync(categoryToDelete);
            await _unitOfWork.CompleteAsync();
            return Ok(categoryToDelete);
        }
        catch (Exception ex)
        {
            _logger.LogError("Exception: {Message}", ex.Message);
            return StatusCode(500, "Internal server error");
        }
    }
}
