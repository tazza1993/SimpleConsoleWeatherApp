using System.Text.Json.Serialization;

namespace RandomCSharp;

public class CurrentWeatherConditions
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    [JsonPropertyName("conditions")]
    public string? CloudDensity { get; set; }
    
    [JsonPropertyName("icon")]
    public string? CloudCoverage { get; set; }

    [JsonPropertyName("sunrise")]
    public string? Sunrise { get; set; }

    [JsonPropertyName("sunset")]
    public string? Sunset { get; set; }
}