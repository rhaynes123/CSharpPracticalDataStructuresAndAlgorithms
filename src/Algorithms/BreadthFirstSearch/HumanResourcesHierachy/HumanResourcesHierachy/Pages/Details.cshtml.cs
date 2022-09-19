using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HumanResourcesHierachy.DAL;
using HumanResourcesHierachy.Features.Employees.Models;
using HumanResourcesHierachy.Features.Employees.DTOS;
using HumanResourcesHierachy.Features;
using MediatR;
using HumanResourcesHierachy.Features.Employees;

namespace HumanResourcesHierachy.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

      public EmployeeDTO Employee { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var employee = await _mediator.Send(new GetEmployeeByIdQuery((int)id));
            if (employee is null)
            {
                return NotFound();
            }
            Employee = employee;
            return Page();
        }
    }
}
