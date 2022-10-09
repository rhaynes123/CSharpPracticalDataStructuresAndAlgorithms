using System;
using System.Text.Json.Serialization;

namespace HourlyForecast.Features.Weather.DTOs
{
    public sealed record Weather
    {
        [JsonPropertyName("id")]
        public int? Id { get; init; }
        [JsonPropertyName("main")]
        public string? Main { get; init; }
        [JsonPropertyName("description")]
        public string? Description { get; init; }
        [JsonPropertyName("icon")]
        public string? Icon { get; init; }
    }
}

