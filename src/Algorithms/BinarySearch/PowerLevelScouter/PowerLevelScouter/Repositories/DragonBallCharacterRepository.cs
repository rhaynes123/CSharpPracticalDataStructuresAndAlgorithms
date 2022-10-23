using System;
using PowerLevelScouter.Models;

namespace PowerLevelScouter.Repositories
{
    public class DragonBallCharacterRepository: ICharacterRepository
    {
        #region
        /*
         * https://dragonball.fandom.com/wiki/List_of_Power_Levels
         */
        #endregion
        public DragonBallCharacterRepository()
        {
        }

        public async Task<Character[]> GetCharactersAsync()
        {
            return await Task.FromResult(new Character[]
            {
                new Character(1,"Goku", 9001),
                new Character(2,"Vegeta", 18000),
                new Character(3,"Piccolo", 3500),
                new Character(4,"Gohan", 2800),
                new Character(5,"Krillin", 1770),
                new Character(6,"Tien", 1830),
                new Character(7,"Yamacha", 1480),
            });
        }
    }
}

