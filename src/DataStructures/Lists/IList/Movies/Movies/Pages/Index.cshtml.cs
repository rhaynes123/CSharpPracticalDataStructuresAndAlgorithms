using System.Collections.Immutable;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movies.Features;
using Movies.Features.Common;
using Movies.Features.Movies.Models;

namespace Movies.Pages;
// https://github.com/martinothamar/Mediator#32-handler-types
// https://www.youtube.com/watch?v=aaFLtcf8cO4
// https://github.com/martinothamar/Mediator
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IMediator _mediator;
    public IndexModel(ILogger<IndexModel> logger
        , IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    public IList<Movie> Movies { get; set; } = ImmutableList<Movie>.Empty;
    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;
    public int Count { get; private set; }
    public int PageSize { get; private set; } = 10;
    public int TotalPages { get; private set; }

    public async Task<IActionResult> OnGet()
    {
        var movies = await _mediator.Send(new GetAllMoviesQuery());
        if(movies is null || !movies.Any())
        {
            _logger.LogWarning("No Movies Found");
            return Page();
        }
        movies = movies.OrderByDescending(movie => movie.ReleaseDate).Take(PageSize);
        int countOfMovies = await movies.CountAsync();
        if (countOfMovies > PageSize)
        {
            var pagedList = await PaginatedList<Movie>.CreateAsync(movies, CurrentPage, PageSize);
            Movies = pagedList;
            TotalPages = pagedList.Total;
            return Page();
        }
        Movies = await movies.ToArrayAsync();
        return Page();
    }
}

