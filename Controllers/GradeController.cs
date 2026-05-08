using Microsoft.AspNetCore.Mvc;
using Siemens.Internship2026.GradeBook.Interfaces;

namespace Siemens.Internship2026.GradeBook.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GradeController : ControllerBase
{
    private readonly IGradeService _gradeService;
    private readonly IGradeStatisticsService _gradeStatisticsService;
    private readonly ILoggerService _loggerService;

    public GradeController(IGradeService gradeService, IGradeStatisticsService gradeStatisticsService, ILoggerService loggerService)
    {
        _gradeService = gradeService;
        _gradeStatisticsService = gradeStatisticsService;
        _loggerService = loggerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _loggerService.Log("GET api/item called");

        var gradesList = await _gradeService.GetAllGradesAsList();
        var statistics = await _gradeStatisticsService.ComputeGradeStatistics();

        //Console.WriteLine($"[LOG] Returning {totalCount} items, average value: {averageValue}");

        return Ok(new
        {
            Data = gradesList,
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

        var returnedGrade = await _gradeService.GetGradeById(id);
        if (returnedGrade == null)
        {
            _loggerService.Log($"Item {id} not found");
            return NotFound($"Item with Id {id} was not found.");
        }

        return Ok(returnedGrade);
    }

    [HttpGet("passing/top/{n}")]
    public async Task<IActionResult> GetFirstNPassingGrades(int n)
    {
        _loggerService.Log($"GET api/grade/passing/top/{n} called");

        if (n <= 0)
        {
            _loggerService.Log($"Invalid n: {n}");
            return BadRequest("N must be a positive integer.");
        }

        var firstNGrades = await _gradeService.GetFirstNPassingActiveGrades(n);
        return Ok(firstNGrades);
    }
}
