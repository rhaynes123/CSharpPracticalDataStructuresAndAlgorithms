using System;
using Microsoft.EntityFrameworkCore;
using SupernaturalBestiary.Entities;

namespace SupernaturalBestiary.Data
{
	public class CreatureDbContext: DbContext
	{
		public CreatureDbContext(DbContextOptions<CreatureDbContext> dbContextOptions): base(dbContextOptions)
		{
		}
		public DbSet<CreatureEntity> Creatures { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CreatureEntity>(creature =>
            {
                creature.HasPartitionKey(creature => creature.Id);
                creature.ToContainer("Creatures");

            });
        }
	}
}

