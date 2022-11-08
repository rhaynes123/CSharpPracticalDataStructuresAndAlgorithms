using System;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Movies.Features.Models;

namespace Movies.Features
{
    public class GetAllMovieQueryHandler : IQueryHandler<GetAllMoviesQuery, IQueryable<Movie>>
    {
        private readonly Movies.Data.MovieDbContext _context;
        public GetAllMovieQueryHandler(Movies.Data.MovieDbContext context)
        {
            _context = context;
        }

        public ValueTask<IQueryable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return new ValueTask<IQueryable<Movie>>(_context.Movies);
        }
    }
}

