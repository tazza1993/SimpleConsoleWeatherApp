using System.Data.Common;
using System.Text.Json.Serialization;

namespace RandomCSharp;

public class WeatherForecast
{

    [JsonPropertyName("resolvedAddress")]
    public string? Location { get; init; }

    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }
    
    [JsonPropertyName("description")]
    public string? Summary { get; init; }

    [JsonPropertyName("currentConditions")]
    public CurrentWeatherConditions? CurrentConditions { get; init; } = new();
}