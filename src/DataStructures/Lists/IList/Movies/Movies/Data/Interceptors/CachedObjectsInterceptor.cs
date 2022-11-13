using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Distributed;
using Movies.Data.Settings;
using Movies.Features.Movies.Extensions;

namespace Movies.Data.Interceptors
{
    // https://www.youtube.com/watch?v=mAlO3OuoQvo&t=464s
    public sealed class CachedObjectsInterceptor: SaveChangesInterceptor
	{
        private readonly IDistributedCache _cache;
        private readonly RedisSettings redisSettings;
		public CachedObjectsInterceptor(IDistributedCache cache, RedisSettings redis)
		{
            _cache = cache;
            redisSettings = redis;
        }
        public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            // Something like this works fine if your system only has one key
            //await _cache.TryRemoveAsync(_cacheKey);

            if (redisSettings is null || redisSettings.keys is null || !redisSettings.keys.Any())
            {
                return await base.SavedChangesAsync(eventData, result, cancellationToken);
            }
            foreach (var key in redisSettings.keys)
            {
                await _cache.TryRemoveAsync(key); // This is a better approach if you have mutliple keys
            }
            return await base.SavedChangesAsync(eventData, result, cancellationToken);
        }
    }
}

