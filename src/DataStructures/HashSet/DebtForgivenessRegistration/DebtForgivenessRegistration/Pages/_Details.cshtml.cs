using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DebtForgivenessRegistration.Data;
using DebtForgivenessRegistration.Features.Customers.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MediatR;
using DebtForgivenessRegistration.Features.Customers;

namespace DebtForgivenessRegistration.Pages;

public class _DetailsModel : PageModel
{
    private readonly IMediator _mediator;

    public _DetailsModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Customer Customer { get; set; } = default!;
    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var Customers = await _mediator.Send(new GetCustomersQuery());
        if (Customers == null || ! await Customers.AnyAsync())
        {
            return Page();
        }
        if (id == null || id == default)
        {
            return NotFound();
        }

        var customer = await Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        Customer = customer;
        return Page();
    }
}
