using System;
namespace Movies.Features.Models.Enums
{
    // https://www.csharpstar.com/csharp-interview-questions-part-4/
    // https://docs.microsoft.com/en-us/dotnet/api/system.enum.getnames?view=net-6.0
    public enum Genre
    {
        //All = ~0,
        SuperHero = 0,
        Horror = 1,
        Comedy = 2,
        Romantic = 8,
        Scifi = 4,
        Adventure = 9,
        Thriller = 6,
        Mythical = 7,
        RomanticComedy = Genre.Romantic | Genre.Comedy,
        ScifiHorror = Genre.Scifi | Genre.Horror,
    }
}

