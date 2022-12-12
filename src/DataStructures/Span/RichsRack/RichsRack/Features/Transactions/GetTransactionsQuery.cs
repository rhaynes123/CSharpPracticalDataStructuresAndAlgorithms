using System;
using Mediator;

namespace RichsRack.Features.Transactions
{
	public sealed record GetTransactionsQuery: IQuery<IQueryable<Transaction>>;
}

