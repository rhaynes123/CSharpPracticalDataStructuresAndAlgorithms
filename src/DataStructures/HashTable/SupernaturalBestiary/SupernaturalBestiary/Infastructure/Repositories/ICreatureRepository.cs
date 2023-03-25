using System;
using SupernaturalBestiary.Domain.Models;

namespace SupernaturalBestiary.Infastructure.Repositories
{
	public interface ICreatureRepository
	{
		Task<IReadOnlyList<Creature>> GetCreaturesAsync();

		Task SaveCreatureAsync(Creature creature);
	}
}

