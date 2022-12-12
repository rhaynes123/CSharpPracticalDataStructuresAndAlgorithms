using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RichsRack.Features.Transactions;

namespace RichsRack.Pages
{
    public class TransactionsModel : PageModel
    {
        private readonly IMediator mediator;
        public IList<Transaction> Transactions { get; set; } = new List<Transaction>();
        public TransactionsModel(IMediator mediator)
        {
            this.mediator = mediator;

        }
        public async Task<IActionResult> OnGet()
        {
            var transactions = await mediator.Send(new GetTransactionsQuery());
            Transactions = await transactions.ToListAsync();
            return Page();

        }
    }
}
