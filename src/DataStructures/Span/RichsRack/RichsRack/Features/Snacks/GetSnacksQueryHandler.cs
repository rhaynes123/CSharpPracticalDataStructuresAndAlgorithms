using System;
using Mediator;
using Microsoft.Extensions.Caching.Distributed;
using RichsRack.Extensions;
using RichsRack.Features.Snacks.Models;
using RichsRack.Persistence;

namespace RichsRack.Features.Snacks
{
	public class GetSnacksQueryHandler: IQueryHandler<GetSnacksQuery, IQueryable<Snack>>
	{
        private readonly SnacksDbContext dbContext;
        private readonly IDistributedCache _cache;
        private readonly string SnacksKey;
        public GetSnacksQueryHandler(SnacksDbContext dbContext
            , IDistributedCache cache
            , IConfiguration configuration)
		{
            this.dbContext = dbContext;
            _cache = cache;
            SnacksKey = configuration["Redis:SnacksKey"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ValueTask<IQueryable<Snack>> Handle(GetSnacksQuery query, CancellationToken cancellationToken)
        {
            var snacks = dbContext.Snacks
                .AsCachedQueryable(_cache, SnacksKey);
            return new ValueTask<IQueryable<Snack>>(snacks);
        }
    }
}

