using Azure.Practise.Configuration.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Azure.Practise.Configuration.Controllers;

[ApiController]
[Route("[controller]")]
public class DynamicWeatherForecastController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly WeatherForecastOptionsV2 _weatherForecastOptions;

    public DynamicWeatherForecastController(
        ILogger<DynamicWeatherForecastController> logger,
        IHttpClientFactory httpClientFactory,
        IOptionsSnapshot<WeatherForecastOptionsV2> weatherForecastOptions) // register Config as scoped
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _weatherForecastOptions = weatherForecastOptions.Value;
    }

    [HttpGet]
    public async Task<string> Get(string cityName = "Brisbane")
    {
        string baseUrl = _weatherForecastOptions.Url;
        string key = _weatherForecastOptions.Key;
        string url = $"{baseUrl}?key={key}&q={cityName}";

        using var client = _httpClientFactory.CreateClient();
        
        return await client.GetStringAsync(url);
    }
}