using System.ComponentModel.DataAnnotations;

namespace Azure.Practise.Configuration.Options;

public class WeatherForecastOptionsV2
{
    public const string WeatherApi = "WeatherApiV2";
    [Required]
    public string Url { get; set; }
    [Required]
    public string Key { get; set; }

    public string Count { get; set; }
}