using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Validators;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

    }

    [HttpPost(Name = "GetWeatherForecast")]
    public async Task<IActionResult> Post([FromBody] AddStudentInputModel model)
    {
        var studentValidator = new AddStudentValidator();

        var result = studentValidator.Validate(model);

        if (result.IsValid)
        {
            return Ok(model);
        }

        var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
        return BadRequest(errorMessages);
    }
}
