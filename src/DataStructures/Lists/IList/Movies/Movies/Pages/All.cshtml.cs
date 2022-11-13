using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Features;
using Movies.Features.Movies.Models;
using Movies.Features.Movies.Models.Enums;

namespace Movies.Pages
{
    public class AllModel : PageModel
    {
        private readonly IMediator _mediator;

        public AllModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IReadOnlyList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public Genre MovieGenre { get; set; } = Genre.All;

        public async Task OnGetAsync()
        {
            Array genres = Enum.GetNames(typeof(Genre));
            var movies = await _mediator.Send(new GetAllMoviesQuery());

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (MovieGenre != Genre.All)
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(genres);
            Movie = (await movies.AsNoTracking().ToListAsync()).AsReadOnly();
        }
    }
}
