using System;
using Mediator;
using RichsRack.Features.Snacks.Models;
using RichsRack.Persistence;

namespace RichsRack.Features.Snacks
{
	public class GetSnacksQueryHandler: IQueryHandler<GetSnacksQuery, IQueryable<Snack>>
	{
        private readonly SnacksDbContext dbContext;
		public GetSnacksQueryHandler(SnacksDbContext dbContext)
		{
            this.dbContext = dbContext;
		}

        public async ValueTask<IQueryable<Snack>> Handle(GetSnacksQuery query, CancellationToken cancellationToken)
        {
            return await ValueTask.FromResult(dbContext.Snacks);
        }
    }
}

