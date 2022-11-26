using System;
using Mediator;
using Microsoft.Extensions.Caching.Distributed;
using Movies.Data.Settings;
using Movies.Features.Movies.Extensions;
using Movies.Features.Movies.Models;

namespace Movies.Features.Movies
{
    public class RemoveMovieCacheHandler : INotificationHandler<ICachable>
    {
        private readonly IDistributedCache _cache;
        private readonly RedisSettings redisSettings;
        public RemoveMovieCacheHandler(IDistributedCache cache, RedisSettings redis)
        {
            _cache = cache;
            redisSettings = redis;
        }
        public async ValueTask Handle(ICachable notification, CancellationToken cancellationToken)
        {
            if (redisSettings is null || redisSettings.keys is null || !redisSettings.keys.Any())
            {
                await ValueTask.CompletedTask;
                return;
            }
            foreach (var key in redisSettings.keys)
            {
                await _cache.TryRemoveAsync(key); // This is a better approach if you have mutliple keys
            }
        }
    }
}

