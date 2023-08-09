namespace Azure.Practise.Configuration;

public class WeatherForecastOptions
{
    public const string WeatherApi = "WeatherApi";
    public string Url { get; set; }
    public string Key { get; set; }
}