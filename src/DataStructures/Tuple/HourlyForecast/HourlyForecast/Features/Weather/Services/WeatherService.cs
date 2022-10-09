using System;
using System.Net;
using HourlyForecast.Features.Location.DTOs;
using HourlyForecast.Features.Weather.DTOs;

namespace HourlyForecast.Features.Weather.Services;

public sealed class WeatherService : IWeatherService
{
    private readonly HttpClient _client;
    private readonly IConfiguration _configuration;
    private readonly string ApiKey;
    public WeatherService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _configuration = configuration;
        _client = httpClientFactory.CreateClient(_configuration["OpenWeatherApi:ClientName"]);
        if (string.IsNullOrWhiteSpace(_configuration["OpenWeatherApi:APIKEY"]))
        {
            throw new ArgumentException("ApiKey Configuration Missing");
        }
        ApiKey = _configuration["OpenWeatherApi:APIKEY"];
    }

    public async Task<(HttpStatusCode, WeatherResponse)> GetWeatherResponseAsync(LocationRequest locationRequest)
    {
        string queryString = $"/data/2.5/weather?lat={locationRequest.latitude}&lon={locationRequest.longitude}&appid={ApiKey}&units=imperial";
        HttpResponseMessage response = await _client.GetAsync(queryString);
        if(response is null)
        {
            throw new NullReferenceException("Response from OpenWeather was null");
        }
        if (response.Content is null)
        {
            return (HttpStatusCode.NoContent, null!);
        }
        WeatherResponse weatherdata = new();
        try
        {
            weatherdata = await response.Content.ReadFromJsonAsync<WeatherResponse>() ?? new();
        }
        catch(Exception)
        {
            return (HttpStatusCode.InternalServerError, new());
        }
        return (response.StatusCode, weatherdata);
    }
}

