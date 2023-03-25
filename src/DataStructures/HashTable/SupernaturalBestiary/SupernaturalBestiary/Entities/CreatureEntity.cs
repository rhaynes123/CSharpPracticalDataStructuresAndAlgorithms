using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SupernaturalBestiary.Entities
{
	public class CreatureEntity
	{
        [Required, JsonPropertyName("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required, JsonPropertyName("name")]
        public required string Name { get; set; }
        [Required, JsonPropertyName("description")]
        public required string Description { get; set; }
        [Required, JsonPropertyName("abilities")]
        public required IDictionary<string, string> Abilities { get; set; }
        public CreatureEntity()
		{
		}
	}
}

