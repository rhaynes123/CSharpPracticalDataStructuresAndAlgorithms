using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MediatR;
using HumanResourcesHierachy.Features.Employees.Models;
using HumanResourcesHierachy.Features.Employees;
using Microsoft.EntityFrameworkCore;

namespace HumanResourcesHierachy.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMediator _mediator;
    public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    [BindProperty]
    public IList<Employee> Employees { get; set; } = new List<Employee>();
    public async Task<IActionResult> OnGet()
    {
        var result = await _mediator.Send(new GetAllEmployeesQuery());
        Employees = await result.ToListAsync();
        return Page();
    }
}

