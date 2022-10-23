using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PowerLevelScouter.Models;
using PowerLevelScouter.Repositories;

namespace PowerLevelScouter.Pages
{
    public class SevenDeadlySinsModel : PageModel
    {
        #region
        /*
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
        public SevenDeadlySinsModel(SevenDeadlySinsCharacterRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Character[] Charaters { get; set; } = Array.Empty<Character>();
        [BindProperty(SupportsGet = true)]
        public int PowerLevelToSearch { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            if (PowerLevelToSearch == 0 || PowerLevelToSearch == default)
            {
                Charaters = await repository.GetCharactersAsync();
                return Page();
            }
            try
            {
                var sevendeadlysinsCharacters = await repository.GetCharactersAsync();
                var characterToRank = sevendeadlysinsCharacters.FirstOrDefault(character => character.PowerLevel == PowerLevelToSearch);
                Array.Sort(sevendeadlysinsCharacters);
                int characterIndex = Array.BinarySearch(sevendeadlysinsCharacters, characterToRank);
                Charaters = sevendeadlysinsCharacters
                    .Where(character => character.Equals(sevendeadlysinsCharacters[characterIndex]))
                    .ToArray();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync([FromBody] int? id)
        {
            if (id is null || id == default)
            {
                return new BadRequestResult();
            }
            try
            {
                var sevendeadlysinsCharacters = await repository.GetCharactersAsync();
                var characterToRank = sevendeadlysinsCharacters.FirstOrDefault(character => character.Id == id);
                if (characterToRank is null || characterToRank == default)
                {
                    return NotFound();
                }
                Array.Sort(sevendeadlysinsCharacters);
                int characterIndex = Array.BinarySearch(sevendeadlysinsCharacters, characterToRank);
                return new OkObjectResult(characterIndex + 1);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
