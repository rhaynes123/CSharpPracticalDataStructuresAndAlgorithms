# The WHY
The dreaded Binary Search algorithim. If you a fresh computer science student than there is a good chance your very familiar with this algorithim. It's one of the most common search algorithims that every computer science/ programming/ software engineering student is taught. With all that said this algorithim also stands out in that it feels like there is just never a good reason to ever try to use it. 

As far as searching goes with functions such as Linq's Single, First or even a Where we C# developers have more than enough functions we can rely on to do searching for a particular item. On top of that a Binary Search unlike the other functions mentioned returns the index of a value meaning that before using a Binary search you have to already know what you are looking for. It took me a great amount of time to figure out when I should really use a Binary Search or where it would benefit me in a practical use case until I realized the key piece to a binary search .. SORTING!

First, Single and Where are not responsible in of themselves for sorting any collection they search through. They merely search the collection for whatever predicate they are looking for. Sure they may do so in a linear pattern but in most cases thats fine for a number of reasons but often because as developers we often focus on keeping whatever collection we are searching through small. This is usually due to most collection being the result of some database query and we are taught to avoid pulling in data we don't need to be concerned about.

This impacts sorting and searching because a sorting algorithim just like a search algorithim has to look through our entire collection in order to do perform sorting. Depending on the size of the collection even the sorting of the collection will take longer than the searching even and this can result in an overall speed degrade that isn't worth it in the long run.
# The WHAT
After even more thought I was finally able to think of a use case where a system would need to sort and entire collection and then return the position of a value instead of looking for that value itself ... a RANKING SYSTEM! 

Any rank system needs to be able to compare different people or items against one another and then determine numerically how they compare against the entire of list in question, ie determining if someone is first, second, third, etc in a race based on their time to complete the race. For our example I chose an anime power scale system. For those of you who aren't famaliar with Japanese anime a common theme in many is to rank the characters based of some numerical fighting ability based power scale. In the west probably one of the most well known of these was Dragon Ball Z which earlier in it's story lines introduced the concept of power levels. Another less popular and more recent anime to do the same is an anime referred to as Seven Deadly Sins. It's characters also have numerical representations of the battling abilities so for this project we are building a system that will show a short list of some characters and give you the ability to see them ranked in comparions to the others.

# The CODE

Ok so now that we have our context and problem to solve lets get to some code. First we're going to create an Character record that are anime characters from both series will be based around. We used a record type here because unlike classes record check equality of value and not reference which will make future code much easier. Another very import part of working with both a sorting algorithim and a binary search algorithim is that the versions of those algorithims built into the C# language need to work off a type that can be compared against and for any reference type like a class or record that means they must inherit from the IComparable interface.

```C#
using System;
namespace PowerLevelScouter.Models
{
    public record Character(int Id, string Name, int PowerLevel, string ImagePath) : IComparable<Character>
    {
        /// <summary>
        /// Compares power level and intends to do so in a descending order.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Character? other)
        {
            if (other is null || other == default)
            {
                return -1;
            }
            if(PowerLevel == other.PowerLevel)
            {
                return 0;
            }
            if(PowerLevel > other.PowerLevel)
            {
                return -1;
            }
            if (PowerLevel < other.PowerLevel)
            {
                return 1;
            }
            return -1;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}


```
The IComparable interface requires the implemenint type to have an implementation of the CompareTo function which will return an int. Pay special attention to our inplementation as it's a bit different than others you might see. So for our use case the unique value we want to compare our objects against is their power levels as this is also what we will use to sort/rank our characters. What different is that fact that the greater than or less than are reversed from normal implementation of this function. To better explain what I mean let me show you a code snipped from [this article by Sam Fields](https://dev.to/samfieldscc/algorithms-in-c-sorting-with-binary-search-3gj#bsa-generic)

```C#
public int CompareTo(Cloud obj)
	{
		if ((int)this.Type == (int)obj.Type)
			return 0;
		if ((int)this.Type < (int)obj.Type)
			return -1;
		if ((int)this.Type > (int)obj.Type)
			return 1;
		return 1;
	}
```
Among many other details that he covers you can see how he's comparing clouds and the types however in a less than case -1 is returned and in the greater than case 1 is returned. For our implementation we have them reversed because the ordering from the above example will force the sorting to be an ascending order meaning the lowest cloud level has the lowest index. Since we are doing ranking we want the opposite, we want the object with the high compared value to have the lowest index. This is one of many ways to do this. A customer comparer type could also be used in place but I found that more complicated than needed and only adding more code than I found benefit from. 

### DragonBall.cshtml.cs
```C#
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
```

### SevenDeadlySins.cshtml.cs
```C#
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
                return new OkObjectResult(new CharacterDetailResponse(name: characterToRank.Name, rank: characterIndex + 1, imagePath: characterToRank.ImagePath));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
```
As you can now see I have 2 different OnPostAsync methods that are nearly identical for the sake of learning purposes but with the CompareTo set I'm now able to get an item's index in a array sorted in descending order. It's being incremented by 1 to better present to non technical users by thats the bulk of the C# code needed to achieve this. I can also write a OnGetAsync that can optionally find a character based off their power level and check if one object is equal to the other since the character type is a record not a class.
```C#
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
```