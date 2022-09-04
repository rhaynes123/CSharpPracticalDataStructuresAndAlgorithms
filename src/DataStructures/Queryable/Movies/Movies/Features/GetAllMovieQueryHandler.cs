using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Movies.Features.Models;

namespace Movies.Features
{
    public class GetAllMovieQueryHandler : IRequestHandler<GetAllMoviesQuery, IQueryable<Movie>>
    {
        private readonly Movies.Data.MovieDbContext _context;
        public GetAllMovieQueryHandler(Movies.Data.MovieDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Movies.AsNoTracking());
        }
    }
}

