using System;
using PowerLevelScouter.Models;

namespace PowerLevelScouter.Repositories
{
    public interface ICharacterRepository
    {
        Task<Character[]> GetCharactersAsync();
    }
}

