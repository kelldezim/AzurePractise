namespace Azure.Practise.Configuration.Options;

public static class Extension
{
    public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<WeatherForecastOptions>(config.GetSection(WeatherForecastOptions.WeatherApi));
        //services.Configure<WeatherForecastOptionsV2>(config.GetSection(WeatherForecastOptionsV2.WeatherApi));
        services.AddOptions<WeatherForecastOptionsV2>()
            .Bind(config.GetSection(WeatherForecastOptionsV2.WeatherApi))
            .ValidateDataAnnotations();
        services.Configure<AzureConfigOptions>(config.GetSection(AzureConfigOptions.AzureConfigKey));
        
        return services;
    }
}