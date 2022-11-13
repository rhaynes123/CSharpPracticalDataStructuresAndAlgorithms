using System;
namespace Movies.Features.Movies.Models.Enums
{
    // https://www.csharpstar.com/csharp-interview-questions-part-4/
    // https://docs.microsoft.com/en-us/dotnet/api/system.enum.getnames?view=net-6.0
    //[Flags]
    public enum Genre
    {
        All = ~0,
        None = 0,
        SuperHero = 1,
        Horror = 2,
        Comedy = 3,
        Romantic = 8,
        Scifi = 4,
        Adventure = 9,
        Thriller = 10,
        Mythical = 7,
        RomanticComedy = Genre.Romantic | Genre.Comedy,
        ScifiHorror = Genre.Scifi | Genre.Horror,
    }
}

