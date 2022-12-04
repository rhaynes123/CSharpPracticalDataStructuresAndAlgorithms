using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RichsRack.Pages;
#region
/*
 * https://www.youtube.com/watch?v=jUZ3VKFyB-A
 * https://code-maze.com/csharp-span-to-improve-application-performance/
 * https://khalidabuhakmeh.com/how-to-add-a-view-to-an-entity-framework-core-dbcontext
 * https://gist.github.com/yzorg/689891a94fc2a49f193d8ba667110b51
 * https://mycodingtips.com/2021/9/20/how-to-run-sql-scripts-in-a-file-using-ef-core-migrations
 */
#endregion
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}

