using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PartyPlanner.Data;
using PartyPlanner.Features.Parties.Models;
using System.Collections.Immutable;

namespace PartyPlanner.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ApplicationDbContext _dbContext;

    [BindProperty]
    public Party NewParty { get; set; } = new();
    [BindProperty]
    public IList<Party> Parties { get; set; } = ImmutableList<Party>.Empty;

    public IndexModel(ILogger<IndexModel> logger,
        ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<IActionResult> OnGet()
    {
        if (User.Identity is null || string.IsNullOrWhiteSpace(User.Identity.Name))
        {
            _logger.LogWarning("User isn't Logged In");
            return Page();
        }
        IList<Party> myParties = await GetMyPartiesWithNoTrackingAsync(User.Identity.Name);

        if (myParties is null || !myParties.Any())
        {
            return Page();
        }
        Parties = myParties;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Model Invalid");
                return Page();
            }
            var addedParty = await _dbContext.Parties.AddAsync(NewParty);
            var saved = await _dbContext.SaveChangesAsync();
            if (addedParty is null || addedParty == default || saved != 1)
            {
                ModelState.AddModelError(string.Empty, "Party Could Not be Saved");
                return Page();
            }
            return Page();
        }
        catch (Exception error)
        {
            _logger.LogCritical("{err}", error.Message);
            ModelState.AddModelError(string.Empty, "Party Could Not be Saved");
            return Page();
        }
        // This is probably one of the worst ways to get this done but this finally should ensure that before any return we will always have the parties return data
        // This will also mean the page will never just crash in theory at least
        finally
        {
            Parties = await GetMyPartiesWithNoTrackingAsync(User.Identity!.Name!);
        }
    }
    /// <summary>
    /// Returns an Array of the items with no query tracking on
    /// As you can see since the data type is an IList it has a high degree of flexbility
    /// Not as flexible as Ienumerable but still I can set the results to a List, an Immutable List, an Array etc.
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    private async Task<IList<Party>> GetMyPartiesWithNoTrackingAsync(string email)
    {
        if (!_dbContext.Parties.Any() || string.IsNullOrWhiteSpace(email))
        {
            return ImmutableList<Party>.Empty;
        }
        return await _dbContext.Parties
            .AsNoTracking()
            .Where(party => party.OwnerEmail == email)
            .ToArrayAsync();
    }
}

