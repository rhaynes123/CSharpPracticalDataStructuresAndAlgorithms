using Mediator;
using Microsoft.Extensions.Caching.Distributed;
using Movies.Data;
using Movies.Data.Settings;
using Movies.Features.Movies.Extensions;
using Movies.Features.Movies.Models;

namespace Movies.Features.Movies
{
    public class CreateMovieCommandHandler : INotificationHandler<CreateMovieCommand>
    {
        private readonly MovieDbContext _context;
        public CreateMovieCommandHandler(MovieDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async ValueTask Handle(CreateMovieCommand notification, CancellationToken cancellationToken)
        {
            await _context.Movies.AddAsync(notification.movie, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
    /// <summary>
    /// THIS IS HERE PURELY FOR DEMONSTRATION PURPOSES
    /// The use of the INotifications means multiple different handlers can respond to the same event.
    /// In this case that even't is the creation of a new movie. One Handler will save to the database
    /// Another will clear our cache data
    /// </summary>
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

