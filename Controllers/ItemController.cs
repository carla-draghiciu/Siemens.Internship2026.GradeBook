using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemService _itemService;
    private readonly ILoggerService _loggerService;

    public ItemController(IItemRepository itemRepository, IItemService itemService, ILoggerService loggerService)
    {
        _itemRepository = itemRepository;
        _itemService = itemService;
        _loggerService = loggerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _loggerService.Log("GET api/item called");

        var items = await _itemRepository.GetAllAsync();
        var itemList = items.ToList();

        var statistics = _itemService.ComputeStatistics(itemList);

        //Console.WriteLine($"[LOG] Returning {totalCount} items, average value: {averageValue}");

        return Ok(new
        {
            Data = itemList,
            Statistics = statistics
        });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        _loggerService.Log($"GET api/item/{id} called");

        if (id <= 0)
        {
            _loggerService.Log($"Invalid id: {id}");
            return BadRequest("Id must be a positive integer.");
        }

        var item = await _itemRepository.GetByIdAsync(id);
        if (item == null)
        {
            _loggerService.Log($"Item {id} not found");
            return NotFound($"Item with Id {id} was not found.");
        }

        return Ok(item);
    }
}
