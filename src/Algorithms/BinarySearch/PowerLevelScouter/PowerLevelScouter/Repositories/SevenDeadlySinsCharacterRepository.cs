using System;
using PowerLevelScouter.Models;

namespace PowerLevelScouter.Repositories
{
    public class SevenDeadlySinsCharacterRepository: ICharacterRepository
    {
        #region
        /*
         * https://nanatsu-no-taizai.fandom.com/wiki/Seven_Deadly_Sins#Members
         */
        #endregion
        public SevenDeadlySinsCharacterRepository()
        {
        }

        public async Task<Character[]> GetCharactersAsync()
        {
            return await Task.FromResult(new Character[]
            {
                new Character(1,"Meliodas", 60000),
                new Character(2,"Escanor", 114000),
                new Character(3,"Ban", 3220),
                new Character(4,"King", 41600),
                new Character(5,"Diana", 8800),
                new Character(6,"Gowther", 35400),
                new Character(7,"Merlin", 4710),
            });
        }
    }
}

