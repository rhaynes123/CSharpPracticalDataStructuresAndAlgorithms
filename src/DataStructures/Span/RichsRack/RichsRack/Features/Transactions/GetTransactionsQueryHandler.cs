using System;
using Mediator;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using RichsRack.Extensions;
using RichsRack.Features.Snacks.Models;
using RichsRack.Persistence;

namespace RichsRack.Features.Transactions
{
	public class GetTransactionsQueryHandler: IQueryHandler<GetTransactionsQuery, IQueryable<Transaction>>
	{
        private readonly SnacksDbContext dbContext;
        private readonly IDistributedCache _cache;
        private readonly string TransactionsKey;
        public GetTransactionsQueryHandler(SnacksDbContext dbContext
            , IDistributedCache cache
            , IConfiguration configuration)
		{
            this.dbContext = dbContext;
            _cache = cache;
            TransactionsKey = configuration["Redis:TransactionsKey"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        public ValueTask<IQueryable<Transaction>> Handle(GetTransactionsQuery query, CancellationToken cancellationToken)
        {
            var transactions = dbContext.Transactions
                .FromSqlRaw("CALL GetAllTransactions()")
                .AsNoTracking()
                .AsCachedQueryable(_cache, TransactionsKey);
            return new ValueTask<IQueryable<Transaction>>(transactions);
        }
    }
}

