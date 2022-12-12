using System;
using Mediator;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Distributed;
using RichsRack.Extensions;
using RichsRack.Features.Common;

namespace RichsRack.Features.Transactions
{
	public class RemoveTransactionCacheNotificationHandler: INotificationHandler<ICachable>
    {
        private readonly IDistributedCache _cache;
        private readonly string TransactionsKey;
        private readonly ILogger<RemoveTransactionCacheNotificationHandler> logger;
        public RemoveTransactionCacheNotificationHandler(IDistributedCache cache
            , IConfiguration configuration
            , ILogger<RemoveTransactionCacheNotificationHandler> logger)
		{
            _cache = cache;
            TransactionsKey = configuration["Redis:TransactionsKey"] ?? throw new ArgumentNullException(nameof(configuration));
            this.logger = logger;
        }

        public async ValueTask Handle(ICachable notification, CancellationToken cancellationToken)
        {
            await _cache.TryRemoveAsync(TransactionsKey); // This is a better approach if you have mutliple keys
            logger.LogInformation("{TransactionsKey} Data Cleared", TransactionsKey);
        }
    }
}

