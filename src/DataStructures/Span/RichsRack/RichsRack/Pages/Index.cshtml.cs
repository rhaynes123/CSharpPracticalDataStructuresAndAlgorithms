using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RichsRack.Features.Snacks;
using RichsRack.Features.Snacks.Models;
using RichsRack.Features.Transactions;

namespace RichsRack.Pages;
#region
/*
 * https://www.youtube.com/watch?v=jUZ3VKFyB-A
 * https://code-maze.com/csharp-span-to-improve-application-performance/
 * https://khalidabuhakmeh.com/how-to-add-a-view-to-an-entity-framework-core-dbcontext
 * https://gist.github.com/yzorg/689891a94fc2a49f193d8ba667110b51
 * https://mycodingtips.com/2021/9/20/how-to-run-sql-scripts-in-a-file-using-ef-core-migrations
 * https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx
 * https://learn.microsoft.com/en-us/ef/core/querying/sql-queries
 * https://referbruv.com/blog/working-with-stored-procedures-in-aspnet-core-ef-core/
 * https://code-maze.com/efcore-execute-stored-procedures/
 * https://www.yogihosting.com/stored-procedures-entity-framework-core/
 * https://www.c-sharpcorner.com/article/apiasp-net-core-web-api-entity-framewor-call-stored-procedure-part-ii/
 */
#endregion
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private IMediator mediator;

    public IList<Snack> Snacks { get; set; } = new List<Snack>();

    public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
    {
        _logger = logger;
        this.mediator = mediator;
    }

    public async Task<IActionResult> OnGet()
    {
        var snacks = await mediator.Send(new GetSnacksQuery());
        Snacks = await snacks.ToListAsync();
        return Page();
    }
    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null || id == default || id == 0)
        {
            return Page();
        }
        var snacks = await mediator.Send(new GetSnacksQuery());
        var snack = await snacks.AsNoTracking().FirstAsync(snack => snack.Id == (int)id);
        var transaction = new Transaction
        {
            Amount = snack.Price,
        };
        await mediator.Publish(new CreateTransactionNotification(transaction));
        return RedirectToPage("Transactions");
    }
}

