using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeStatisticsService _statisticsService;
    private readonly ILoggerService _loggerService;

    public GradeController(IGradeStatisticsService itemService, ILoggerService loggerService)
    {
        _statisticsService = itemService;
        _loggerService = loggerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _loggerService.Log("GET api/item called");

        var itemList = await _statisticsService.GetAllAsList();
        var statistics = await _statisticsService.ComputeStatistics();

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

        var item = await _statisticsService.GetById(id);
        if (item == null)
        {
            _loggerService.Log($"Item {id} not found");
            return NotFound($"Item with Id {id} was not found.");
        }

        return Ok(item);
    }
}
