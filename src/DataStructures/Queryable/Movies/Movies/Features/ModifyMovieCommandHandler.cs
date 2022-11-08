using System;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Features.Models;
namespace Movies.Features;

public class ModifyMovieCommandHandler : IRequestHandler<ModifyMovieCommand, Movie>
{
    private readonly MovieDbContext _context;
    public ModifyMovieCommandHandler(MovieDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async ValueTask<Movie> Handle(ModifyMovieCommand request, CancellationToken cancellationToken)
    {
        _context.Attach(request.movie).State = EntityState.Modified;
        int saved = await _context.SaveChangesAsync(cancellationToken);
        if (saved is not 1)
        {
            throw new InvalidOperationException("Save Changes Failed");
        }
        return request.movie;
    }
}

