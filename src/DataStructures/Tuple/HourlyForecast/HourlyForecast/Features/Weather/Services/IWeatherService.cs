using System;
using System.Net;
using HourlyForecast.Features.Location.DTOs;
using HourlyForecast.Features.Weather.DTOs;

namespace HourlyForecast.Features.Weather.Services
{
    public interface IWeatherService
    {
        Task<(HttpStatusCode, WeatherResponse)> GetWeatherResponseAsync(LocationRequest locationRequest);
    }
}

