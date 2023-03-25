using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupernaturalBestiary.Application.ViewModels
{
	public class CreateCreatureViewModel
	{
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Description { get; set; }
		[Required]
		public required IList<Ability> Abilities { get; set; } = new List<Ability>();
        public CreateCreatureViewModel()
		{
		}
	}

	public sealed class Ability
	{
		public required string Name { get; set; }
		public required string Description { get; set; }
	}
}

