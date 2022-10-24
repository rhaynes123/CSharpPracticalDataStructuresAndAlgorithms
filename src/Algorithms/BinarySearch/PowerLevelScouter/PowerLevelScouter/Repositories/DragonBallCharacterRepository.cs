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
                new Character(1,"Goku", 9001,"https://pm1.narvii.com/6495/9179d61db04518dcc9ff6bd32ab384eb2d1717a3_hq.jpg"),
                new Character(2,"Vegeta", 18000,"http://pm1.narvii.com/6509/e8212394383597af098e2c1f31292b30a7bbff42_00.jpg"),
                new Character(3,"Piccolo", 3500,"http://pm1.narvii.com/6729/67c4a9231e8c95304bd891fc076a7371bf5883f7v2_00.jpg"),
                new Character(4,"Gohan", 2800,"http://pm1.narvii.com/6048/7ad065048fb89955cfeaf1af85c1c1b0a06c9210_00.jpg"),
                new Character(5,"Krillin", 1770,"http://pm1.narvii.com/6807/15c3c2d1b5a25a0f50ce68ec9d5f48aed1a2786fv2_00.jpg"),
                new Character(6,"Tien", 1830,"https://pm1.narvii.com/5798/a21ca791c42b1188de1fa92e034c7d05e6343ee3_hq.jpg"),
                new Character(7,"Yamacha", 1480,"http://pm1.narvii.com/6645/62cf2c09c130ae7a1d9d5f3972e51d022e250271_00.jpg"),
            });
        }
    }
}

