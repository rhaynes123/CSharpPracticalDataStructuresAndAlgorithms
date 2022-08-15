using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using BarberShop.Data;
using BarberShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
namespace BarberShop.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ShopDbContext _context;
    /// <summary>
    /// I've decided to use an IDictionary to show that any type that inherits from this interface could be used here
    /// for example by default this will be set to an Immutable dictionary of a string and decimal but it will be empty
    /// This is different than null in that a foreach operation can occur and not throw an exception but just won't loop since it's empty
    /// </summary>
    [BindProperty]
    public IDictionary<string, decimal> Menu { get; set; } = ImmutableDictionary<string, decimal>.Empty;

    public IndexModel(ILogger<IndexModel> logger, ShopDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    /// <summary>
    /// This is a good example use for a dictionary since a menu or list of services is usually just that service and its price a key value pair
    /// </summary>
    /// <returns></returns>
    public IActionResult OnGet()
    {
        //Both of these below lines are purposefully redundant to display a few good practices and options
        // First if the context services is somehow null then its set to an empty collection of service that should allocate any memory but won't cause a null reference if someone misses if
        IEnumerable<Service> services = _context.Services ?? Enumerable.Empty<Service>();
        //Next if the services where somehow null or there was not anything in that collection we instantly return the page blank. This prevents the need for an else block since we just return if things go bad
        //We also log some warning messages since in our use case this should be something to raise alerts. 
        if(services is null || !services.Any())
        {
            string message = "No services where found";
            _logger.LogWarning("Warning: {message}", message);
            return Page();
        }
        //While it's not needed in this use case note the use of the stringcomparer not to be confused with the StringComparison enum
        // This helps when the string key might be of different casing
        Menu = services.ToDictionary(s => s.Name, s => s.Price, StringComparer.OrdinalIgnoreCase);
        return Page();
    }
}

