using System;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Movies.Data;
using Movies.Features.Movies.Models;
using Movies.Features.Movies.Extensions;
using Movies.Data.Settings;

namespace Movies.Features
{
    public class GetAllMovieQueryHandler : IQueryHandler<GetAllMoviesQuery, IQueryable<Movie>>
    {
        private readonly MovieDbContext _context;
        private readonly IDistributedCache _cache;
        private readonly RedisSettings _redisSettings;
        public GetAllMovieQueryHandler(MovieDbContext context
            ,IDistributedCache cache
            , RedisSettings redisSettings)
        {
            _context = context;
            _cache = cache;
            _redisSettings = redisSettings;
        }

        public async ValueTask<IQueryable<Movie>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            IQueryable<Movie> movies = await _context.Movies
                .AsCachedQueryable(_cache, _redisSettings.keys.First());// This is an awful way to get the key but it will work for demo purposes
            return await ValueTask.FromResult(movies);
        }
    }
}

