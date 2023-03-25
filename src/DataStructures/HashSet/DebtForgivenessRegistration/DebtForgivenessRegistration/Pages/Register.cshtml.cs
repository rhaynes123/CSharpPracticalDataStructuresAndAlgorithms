using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DebtForgivenessRegistration.Data;
using DebtForgivenessRegistration.Features.Customers.Models;
using MediatR;
using DebtForgivenessRegistration.Features.Customers;
using DebtForgivenessRegistration.Features.Customers.Specifications;

namespace DebtForgivenessRegistration.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IMediator _mediator;

        public RegisterModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || Customer == null)
            {
                ModelState.AddModelError(string.Empty,"Customer Invalid");
                return Page();
            }
            var customerSpec = new CustomerWithDebtSpecification(Customer);
            if (!customerSpec.SatisfiedBy(Customer))
            {
                ModelState.AddModelError(string.Empty, "Customer Does Not Meed Qualifications For Debt Forgiveness");
                return Page();
            }

            await _mediator.Publish(new CreateCustomerCommand(Customer));

            return RedirectToPage("./Index");
        }
    }
}
