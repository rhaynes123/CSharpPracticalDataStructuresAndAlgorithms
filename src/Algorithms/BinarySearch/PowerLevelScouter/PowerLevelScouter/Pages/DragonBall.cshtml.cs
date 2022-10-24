using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PowerLevelScouter.DTOs;
using PowerLevelScouter.Models;
using PowerLevelScouter.Repositories;

namespace PowerLevelScouter.Pages
{
    public class DragonBallModel : PageModel
    {
        #region
        /*
         ** https://dev.to/samfieldscc/algorithms-in-c-sorting-with-binary-search-3gj#bsa-generic
         * https://dotnetfiddle.net/6xmER0
         * https://dragonball.fandom.com/wiki/List_of_Power_Levels
         * https://nanatsu-no-taizai.fandom.com/wiki/Seven_Deadly_Sins#Members
         * https://weblogs.asp.net/yousefjadallah/using-array-binarysearch-generic-method-with-custom-object
         * https://dragonball.fandom.com/wiki/List_of_Power_Levels
         * http://www.java2s.com/Tutorials/CSharp/Array/How_to_use_BinarySearch_method_to_search_a_sorted_C_array.htm
         * https://dotnetfiddle.net/6xmER0
         * https://weblogs.asp.net/yousefjadallah/using-array-binarysearch-generic-method-with-custom-object
         * https://www.aspsnippets.com/Articles/Open-Show-jQuery-Dialog-Modal-Popup-after-AJAX-Call-Success.aspx
         * https://stackoverflow.com/questions/54901988/confused-about-binarysearch-after-reverse
         * https://stackoverflow.com/questions/8067643/binary-search-of-a-sorted-array
         * https://stackoverflow.com/questions/26786135/binarysearch-array-of-objects-by-id
         */
        #endregion
        private readonly ICharacterRepository repository;
        public DragonBallModel(DragonBallCharacterRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Character[] Charaters { get; set; } = Array.Empty<Character>();
        [BindProperty(SupportsGet = true)]
        public int PowerLevelToSearch { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if(PowerLevelToSearch == 0 || PowerLevelToSearch == default)
            {
                Charaters = await repository.GetCharactersAsync();
                return Page();
            }
            try
            {
                var dbzCharacters = await repository.GetCharactersAsync();
                var characterToRank = dbzCharacters.FirstOrDefault(character => character.PowerLevel == PowerLevelToSearch);
                Array.Sort(dbzCharacters);
                int characterIndex = Array.BinarySearch(dbzCharacters, characterToRank);
                Charaters = dbzCharacters
                    .Where(character => character.Equals(dbzCharacters[characterIndex]))
                    .ToArray();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync([FromBody]int? id)
        {
            if(id is null || id == default)
            {
                return new BadRequestResult();
            }
            try
            {
                var dbzCharacters = await repository.GetCharactersAsync();
                var characterToRank = dbzCharacters.FirstOrDefault(character => character.Id == id);
                if (characterToRank is null || characterToRank == default)
                {
                    return NotFound();
                }
                Array.Sort(dbzCharacters);
                int characterIndex = Array.BinarySearch(dbzCharacters, characterToRank);
                return new OkObjectResult(new CharacterDetailResponse(name:characterToRank.Name, rank:characterIndex + 1, imagePath: characterToRank.ImagePath ));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
