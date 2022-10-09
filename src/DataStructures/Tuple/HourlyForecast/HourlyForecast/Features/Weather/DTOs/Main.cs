using System;
using System.Text.Json.Serialization;

namespace HourlyForecast.Features.Weather.DTOs
{
    public sealed record Main
    {
        [JsonPropertyName("temp")]
        public decimal Temp { get; init; }
        [JsonPropertyName("feels_like")]
        public decimal FeelsLike { get; init; }
        [JsonPropertyName("temp_min")]
        public decimal TempMin { get; init; }
        [JsonPropertyName("temp_max")]
        public decimal TempMax { get; init; }
    }
}

