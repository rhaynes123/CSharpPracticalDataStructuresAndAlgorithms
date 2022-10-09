using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HourlyForecast.Features.Location.DTOs
{
    public sealed record LocationRequest()
    {
        public LocationRequest(decimal? lat, decimal? lon) : this()
        {
            if(lat is null || lon is null || lat == 0 || lon == 0)
            {
                throw new ArgumentException($"Latitude and/or Longitude are invalid {lat},{lon}");
            }
            latitude = lat;
            longitude = lon;
        }
        [Required, JsonPropertyName("latitude")]
        public decimal? latitude { get; init; }
        [Required, JsonPropertyName("longitude")]
        public decimal? longitude { get; init; }
    }
}

