using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PowerLevelScouter.Pages;

public class IndexModel : PageModel
{
    #region
    /*
     * https://dev.to/samfieldscc/algorithms-in-c-sorting-with-binary-search-3gj#bsa-generic
     * https://dotnetfiddle.net/6xmER0
     * https://dragonball.fandom.com/wiki/List_of_Power_Levels
     * https://nanatsu-no-taizai.fandom.com/wiki/Seven_Deadly_Sins#Members
     * https://weblogs.asp.net/yousefjadallah/using-array-binarysearch-generic-method-with-custom-object
     */
    #endregion
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    }
}

