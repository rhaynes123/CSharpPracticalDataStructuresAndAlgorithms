using System;
using Mediator;
using RichsRack.Features.Common;

namespace RichsRack.Features.Transactions
{
	public sealed record CreateTransactionNotification(Transaction Transaction): ICachable;
}

