using Azure.Practise.Configuration.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Azure.Practise.Configuration.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOptionsSnapshot<AzureConfigOptions> _config;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IOptionsSnapshot<AzureConfigOptions> config)
    {
        _logger = logger;
        _config = config;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var count = _config.Value.Count;
        
        _logger.LogInformation(_config.Value.Source ?? "Information");
        
        return Enumerable.Range(1, count).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
