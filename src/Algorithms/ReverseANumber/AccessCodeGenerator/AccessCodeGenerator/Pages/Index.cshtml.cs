using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AccessCodeGenerator.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    private readonly IConfiguration _configuration;

    public string _GeneratedNumber { get; private set; } = default!;


    public IndexModel(ILogger<IndexModel> logger
        ,IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public void OnGet()
    {
        
    }

    public void OnPost()
    {
        string reverseString = ReverseSeed();
        _GeneratedNumber = reverseString + DateTime.Now.ToString("MMddyyyyHHmmss");
    }

    private string ReverseSeed()
    {
        
        int seed = int.Parse(_configuration["SeedValue"] ?? "0");
        int reversedNumber = 0;
        while(seed !=0)
        {
            int lastDigit = seed % 10;
            reversedNumber = reversedNumber * 10 + lastDigit;
            seed /= 10;
        }
        return $"{reversedNumber}";
    }
}

