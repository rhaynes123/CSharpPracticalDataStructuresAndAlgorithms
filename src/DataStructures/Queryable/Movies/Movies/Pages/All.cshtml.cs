using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Features;
using Movies.Features.Models;
using Movies.Features.Models.Enums;

namespace Movies.Pages
{
    public class AllModel : PageModel
    {
        private readonly IMediator _mediator;

        public AllModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IList<Movie> Movie { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public async Task OnGetAsync()
        {
            Array genres = Enum.GetNames(typeof(Genre));
            var movies = await _mediator.Send(new GetAllMoviesQuery());

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(genres);
            Movie = await movies.ToListAsync();
        }
    }
}
