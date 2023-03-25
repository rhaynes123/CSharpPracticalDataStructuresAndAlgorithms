using System;
using System.Collections;

namespace SupernaturalBestiary.Domain.Models
{
	public sealed class Creature
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
		public Hashtable Abilities { get; set; }
		public Creature(Hashtable abilities)
		{
			Abilities = abilities;
		}
	}
}

