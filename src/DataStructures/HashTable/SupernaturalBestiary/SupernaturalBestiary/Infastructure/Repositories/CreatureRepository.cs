using System;
using System.Collections;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SupernaturalBestiary.Data;
using SupernaturalBestiary.Domain.Models;
using SupernaturalBestiary.Entities;

namespace SupernaturalBestiary.Infastructure.Repositories
{
	public sealed class CreatureRepository: ICreatureRepository
	{
        private readonly CreatureDbContext _creatureDbContext;

        public CreatureRepository(CreatureDbContext creatureDbContext)
        {
            _creatureDbContext = creatureDbContext;
        }

        public async Task<IReadOnlyList<Creature>> GetCreaturesAsync()
        {
            var creatureEntities = await _creatureDbContext.Creatures.ToListAsync();

            return creatureEntities.Select(entity =>
            {
                var abilities = entity.Abilities.ToDictionary(ability => ability.Key, ability => ability.Value, StringComparer.OrdinalIgnoreCase);
                var abilityTable = new Hashtable(abilities);
                return new Creature(abilityTable)
                {
                    Name = entity.Name,
                    Description = entity.Description
                };

            }).ToList();
        }

        public async Task SaveCreatureAsync(Creature creature)
        {
            var abilities = creature.Abilities.Values as Dictionary<string, string>;
            CreatureEntity creatureEntity = new()
            {
                Name = creature.Name,
                Description = creature.Description,
                Abilities = abilities ?? throw new ArgumentNullException("abilities")

            };
            await _creatureDbContext.Creatures.AddAsync(creatureEntity);
            await _creatureDbContext.SaveChangesAsync();
        }
    }
}

