using System;
namespace SupernaturalBestiary.Infastructure.Options
{
	public sealed record CosmosDbSettings
	{
		public required string Account { get; init; }
		public required string Key { get; init; }
		public required string DatabaseName { get; init; }
		public required string ContainerName { get; init; }

    }
}

