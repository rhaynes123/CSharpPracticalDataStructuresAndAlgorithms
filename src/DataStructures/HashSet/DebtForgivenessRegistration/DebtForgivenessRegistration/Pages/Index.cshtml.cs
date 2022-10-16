using DebtForgivenessRegistration.Features.Customers;
using DebtForgivenessRegistration.Features.Customers.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DebtForgivenessRegistration.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMediator _mediator;

    public IndexModel(ILogger<IndexModel> logger
        , IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [BindProperty]
    public HashSet<Customer> customers { get; set; } = new HashSet<Customer>();
    public async Task<IActionResult> OnGetAsync()
    {
        var customerResults = await _mediator.Send(new GetCustomersQuery());
        if (customerResults is null || customerResults == default || !customerResults.Any())
        {
            return Page();
        }
        customers = customerResults
            .AsNoTracking()
            .ToHashSet();
        return Page();
    }
}

