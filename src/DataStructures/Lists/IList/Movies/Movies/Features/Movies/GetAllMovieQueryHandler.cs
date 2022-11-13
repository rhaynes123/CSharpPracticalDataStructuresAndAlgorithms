using System;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Movies.Data;
using Movies.Features.Movies.Models;
using Movies.Features.Movies.Extensions;

namespace Movies.Features
{
    public class GetAllMovieQueryHandler : IQueryHandler<GetAllMoviesQuery, IQueryable<Movie>>
    {
        private readonly MovieDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly string _cacheKey;
        public GetAllMovieQueryHandler(MovieDbContext context
            ,IDistributedCache cache
            ,IConfiguration configuration)
        {
            _context = context;
            _cache = cache;
            _cacheKey = configuration["Redis:Key"];
        }

        public async ValueTask<IQueryable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Movie> movies = await _context.Movies
                .AsCachedQueryable(_cache, _cacheKey);
            return await ValueTask.FromResult(movies);
        }
    }
}

