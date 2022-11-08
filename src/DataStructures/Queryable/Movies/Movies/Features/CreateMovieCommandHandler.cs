using System;
using Mediator;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movies.Data;
using Movies.Features.Models;

namespace Movies.Features
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, Movie>
    {
        private readonly MovieDbContext _context;
        public CreateMovieCommandHandler(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async ValueTask<Movie> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            EntityEntry<Movie> added = await _context.Movies.AddAsync(request.movie, cancellationToken);
            int saved = await _context.SaveChangesAsync(cancellationToken);
            if(saved is not 1)
            {
                throw new InvalidOperationException("Save Changes Failed");
            }
            return await ValueTask.FromResult(added.Entity);
        }
    }
}

