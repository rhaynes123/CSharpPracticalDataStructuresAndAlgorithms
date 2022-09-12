using System;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Features.Models;
using Movies.Features.Models.Enums;

namespace MovieIntegrationTests.Features.Movies;

// https://www.youtube.com/watch?v=ZTWl2s8ScMc
//https://stackoverflow.com/questions/54264787/unit-testing-with-ef-core-and-in-memory-database
//https://putridparrot.com/blog/auto-generating-test-data-with-bogus/
//https://khalidabuhakmeh.com/seed-entity-framework-core-with-bogus
//https://www.youtube.com/watch?v=AXu_5UBG2Qk&t=173s
public class MovieDbContextFixture : IDisposable
{
    public readonly MovieDbContext movieDbContext;
    public MovieDbContextFixture()
    {
        DbContextOptionsBuilder<MovieDbContext> builder = new();
        builder
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();

        movieDbContext = new MovieDbContext(builder.Options);
        movieDbContext.Database.EnsureDeleted();
        movieDbContext.Database.EnsureCreated();
    }

    public void Dispose()
    {
        movieDbContext.Database.EnsureDeleted();
        movieDbContext.Dispose();
    }

    public void LoadTestData()
    {
        try
        {
            movieDbContext.Database.EnsureDeleted();
            movieDbContext.Database.EnsureCreated();
            var fakemovies = Enumerable.Range(1, 5).Select(id =>
            {
                var random = new Random();
                Genre randomGenre = (Genre)random.Next(1, 5);
                return new Movie { ID = id, Genre = randomGenre, ReleaseDate = DateTime.Now };
            }).ToList();

            movieDbContext.Movies.AddRange(fakemovies);
            movieDbContext.SaveChanges();
        }
        catch(System.InvalidOperationException )
        {
            Dispose();
        }
        
    }
}
