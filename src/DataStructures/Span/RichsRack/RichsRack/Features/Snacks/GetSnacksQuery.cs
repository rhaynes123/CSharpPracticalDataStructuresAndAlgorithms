using System;
using Mediator;
using RichsRack.Features.Snacks.Models;

namespace RichsRack.Features.Snacks
{
	public sealed record GetSnacksQuery(): IQuery<IQueryable<Snack>>;
}

