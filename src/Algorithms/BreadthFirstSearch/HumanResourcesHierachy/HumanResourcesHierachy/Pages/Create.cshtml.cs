using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HumanResourcesHierachy.DAL;
using HumanResourcesHierachy.Features.Employees.Models;
using HumanResourcesHierachy.Features.Employees.Models.Enums;
using HumanResourcesHierachy.Features.Employees;

namespace HumanResourcesHierachy.Pages;

public class CreateModel : PageModel
{
    private readonly IMediator _mediator;

    public CreateModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        var employees = await _mediator.Send(new GetAllEmployeesQuery());
        var managers = employees
            .Where(emp => emp.EmployeeRoles
            .Any(r => r.Role == Role.Manager
            || r.Role == Role.CTO
            || r.Role == Role.CEO
            || r.Role == Role.SeniorSoftwareEngineer
            && r.DeactivatedDateTime == null));

        ViewData["ManagerId"] = new SelectList(managers, "Id", "FirstName");
        return Page();
    }

    [BindProperty]
    public CreateEmployeeViewModel Employee { get; set; } = default!;
    

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid  || Employee == null)
        {
            ModelState.AddModelError(string.Empty, "Model Was Invalid");
            return Page();
        }

        Employee employee = new Employee()
        {
            FirstName = Employee.FirstName,
            LastName = Employee.LastName,
            EmployeeNumber = Employee.EmployeeNumber,
            DateOfBirth = DateOnly.FromDateTime(Employee.DateOfBirth),
            ManagerId = Employee.ManagerId,
            EmployeeRoles = new List<EmployeeRole>
            {
                new EmployeeRole
                {
                    Role = Employee.Role
                }
            }
        };

        var result = await _mediator.Send(new CreatedEmployeeCommand(employee));

        return RedirectToPage("./Details", new { id = result.Id });
    }
}
