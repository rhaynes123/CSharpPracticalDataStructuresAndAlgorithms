using System.Net;
using HourlyForecast.Features.Location.DTOs;
using HourlyForecast.Features.Weather.DTOs;
using HourlyForecast.Features.Weather.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HourlyForecast.Pages;

public class IndexModel : PageModel
{
    #region
    /*
     * https://www.tutorialsteacher.com/webapi/consume-web-api-post-method-in-aspnet-mvc
     * https://www.typescriptlang.org/docs/handbook/2/classes.html
     * https://developer.okta.com/blog/2019/03/26/build-a-crud-app-with-aspnetcore-and-typescript
     * https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-aspnet-with-typescript?view=vs-2022
     * https://stackoverflow.com/questions/65898507/fetch-post-method-with-razor-page-doesnt-send-body
     * https://stackoverflow.com/questions/64311126/ajax-post-to-handler-functions-in-razor-pages
     * https://www.abhith.net/blog/aspnet-core-return-500-internal-server-error-or-any-other-status-code-from-api/
     * https://stackoverflow.com/questions/52649979/failed-to-bind-to-address-already-in-use-error-with-visual-studio-mac-api
     * https://www.learnrazorpages.com/razor-pages/model-binding
     */
    #endregion

    #region Private Readonly Members
    private readonly ILogger<IndexModel> _logger;
    private readonly IWeatherService _weatherService;
    #endregion

    #region Public Properties
    [BindProperty]
    public WeatherResponse weatherResponse { get; set; } = default!;
    [BindProperty(SupportsGet = true)]
    public decimal? Latitude { get; set; }
    [BindProperty(SupportsGet = true)]
    public decimal? Longitude { get; set; }
    #endregion

    public IndexModel(ILogger<IndexModel> logger, IWeatherService weatherService)
    {
        _logger = logger;
        _weatherService = weatherService;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        if (!ModelState.IsValid || Latitude is null || Longitude is null)
        {
            return Page();
        }
        LocationRequest request = new LocationRequest(lat: Latitude, lon: Longitude);
        (HttpStatusCode statusCode, WeatherResponse response) result = default;
        try
        {
            result = await _weatherService.GetWeatherResponseAsync(request);
        }
        catch (Exception ex)
        {
            _logger.LogError("FAILED: Get Weather - ${StatusCode}, ${Error}", StatusCodes.Status500InternalServerError, ex.Message);
            ModelState.AddModelError($"{StatusCodes.Status500InternalServerError}", "Critical Error Occurred Check Logs for Details");
            return Page();
        }
        if (result.statusCode is not HttpStatusCode.OK)
        {
            ModelState.AddModelError(string.Empty, $"A status code of {(int)result.statusCode} was encountered. Weather data could not be displayed");
            return Page();
        }
        weatherResponse = result.response;
        return Page();
    }

}

