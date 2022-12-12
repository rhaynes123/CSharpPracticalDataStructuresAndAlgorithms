using System;
using Microsoft.EntityFrameworkCore;
using RichsRack.Features.Snacks.Models;
using RichsRack.Features.Transactions;

namespace RichsRack.Persistence
{
	public class SnacksDbContext: DbContext
	{
		public SnacksDbContext(DbContextOptions<SnacksDbContext> options): base(options)
		{
		}
		public DbSet<Snack> Snacks { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
	}
}

