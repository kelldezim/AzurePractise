namespace Azure.Practise.Configuration.Options;

public class AzureConfigOptions
{
    public const string AzureConfigKey = "weather";
    public int Count { get; set; }
    public string Source { get; set; }
}