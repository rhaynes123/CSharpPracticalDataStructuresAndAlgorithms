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
                new Character(1,"Meliodas", 60000,"http://pm1.narvii.com/6389/3784d4a6f6b53c53a88148252deb1caae23fb779_00.jpg"),
                new Character(2,"Escanor", 114000,"http://pm1.narvii.com/7527/e5bc95586e948057249fd5eb7da71c24c1cf06ebr1-1200-800v2_uhq.jpg"),
                new Character(3,"Ban", 3220,"http://pm1.narvii.com/6360/db3d79b568e0cbf9530d8bf296b1077b9c12d7b8_00.jpg"),
                new Character(4,"King", 41600,"http://pm1.narvii.com/6202/50c8ed33e52c320748be39970465838b1c5f8f6f_00.jpg"),
                new Character(5,"Diane", 8800,"http://pm1.narvii.com/6792/e4a4ef9a097fc3affc495fb255e21ffeb69b98c0v2_00.jpg"),
                new Character(6,"Gowther", 35400,"http://pm1.narvii.com/7241/cc884931e05cacf62943aa1adf9cfc6701b3ea81r1-665-778v2_uhq.jpg"),
                new Character(7,"Merlin", 4710,"https://pm1.narvii.com/5940/2203597b3cc1adf618c2a4eeb2ecb5406d0a8e75_hq.jpg"),
            });
        }
    }
}

