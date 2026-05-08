using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemReader _reader;
    private readonly IItemService _itemService;

    public ItemController(IItemReader reader, IItemService itemService)
    {
        _reader = reader;
        _itemService = itemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        Console.WriteLine($"[LOG] {DateTime.UtcNow}: GET api/item called");

        var items = await _reader.GetAllAsync();
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
        Console.WriteLine($"[LOG] {DateTime.UtcNow}: GET api/item/{id} called");

        if (id <= 0)
        {
            Console.WriteLine($"[LOG] Invalid id: {id}");
            return BadRequest("Id must be a positive integer.");
        }

        var item = await _reader.GetByIdAsync(id);
        if (item == null)
        {
            Console.WriteLine($"[LOG] Item {id} not found");
            return NotFound($"Item with Id {id} was not found.");
        }

        return Ok(item);
    }
}
