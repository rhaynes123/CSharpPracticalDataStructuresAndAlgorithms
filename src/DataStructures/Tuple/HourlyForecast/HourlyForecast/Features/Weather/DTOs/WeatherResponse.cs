using System;
using System.Text.Json.Serialization;

namespace HourlyForecast.Features.Weather.DTOs;

public sealed record WeatherResponse()
{
    [JsonPropertyName("main")]
    public Main? Main { get; init; }
    [JsonPropertyName("weather")]
    public IEnumerable<Weather>? Weathers { get; init; }
}

