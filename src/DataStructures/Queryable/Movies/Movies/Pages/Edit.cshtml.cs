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
using Movies.Features.Models;

namespace Movies.Pages;
/// <summary>
/// Built via
/// https://docs.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/da1?view=aspnetcore-6.0
/// </summary>
public class EditModel : PageModel
{
    private readonly IMediator _mediator;

    public EditModel(IMediator mediator)
    {
        _mediator = mediator;
    }

    [BindProperty]
    public Movie Movie { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        var movies = await _mediator.Send(new GetAllMoviesQuery());
        if (id == null || !movies.Any())
        {
            return NotFound();
        }

        var movie =  await movies.FirstOrDefaultAsync(m => m.ID == id);
        if (movie == null)
        {
            return NotFound();
        }
        Movie = movie;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var result = await _mediator.Send(new ModifyMovieCommand(Movie));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await MovieExists(Movie.ID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private async Task<bool> MovieExists(int id)
    {
        var movies = await _mediator.Send(new GetAllMoviesQuery());
        return (movies?.Any(e => e.ID == id)).GetValueOrDefault();
    }
}
