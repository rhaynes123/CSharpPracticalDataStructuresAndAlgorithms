using System;
using System.Text.Json.Serialization;

namespace Movies.Data.Settings
{
	
	public class RedisSettings
	{
		[JsonPropertyName("keys")]
		public string[] keys { get; set; } = Array.Empty<string>();
	}
}

