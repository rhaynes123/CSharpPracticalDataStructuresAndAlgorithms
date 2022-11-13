using System;
using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Features.Movies.Models;

namespace MoviesBenchmark
{
    // https://khalidabuhakmeh.com/seed-entity-framework-core-with-bogus
    // https://stackoverflow.com/questions/54219742/mocking-ef-core-dbcontext-and-dbset
    // https://www.youtube.com/watch?v=ZTWl2s8ScMc
    // https://www.briangetsbinary.com/software%20engineering/dotnet/csharp/performance/2022/05/26/benchmarkdotnet-ef-core-vs-ef-6-part-1.html
    // https://putridparrot.com/blog/auto-generating-test-data-with-bogus/
    // https://stackoverflow.com/questions/54264787/unit-testing-with-ef-core-and-in-memory-database
    [MemoryDiagnoser(false)]
    public class MovieDbContextBenchMark
    {
        /// <summary>
        /// WARNING! THESE ARE SLOW BENCHMARKS AND ARE FOR LEARNING PURPOSES ONLY AT THIS POINT
        /// Each constructor is currently creating a new database with 2000 records and then destroys the database right after so be aware that is ALOT!
        /// </summary>
        [Params(0,1,10, 100, 500, 1999)]
        public int targetId { get; set; }
        #region FirstOrDefaultTests
        [Benchmark]
        public void FirstOrDefaultOnIquerayble()
        {
            MovieDbContextTest benchMark = new();
            var results = benchMark.GetMoviesAsIQuerayble();
            var first = results.FirstOrDefault(x => x.ID == targetId);
            benchMark.Dispose();
        }

        [Benchmark]
        public void FirstOrDefaultOnList()
        {
            MovieDbContextTest benchMark = new();
            var results = benchMark.GetMoviesAsList();
            var first = results.FirstOrDefault(x => x.ID == targetId);
            benchMark.Dispose();
        }

        [Benchmark]
        public async Task FirstOrDefaultOnIqueraybleAsync()
        {
            MovieDbContextTest benchMark = new();
            var results = await benchMark.GetMoviesAsIQueraybleAsync();
            var first = results.FirstOrDefaultAsync(x => x.ID == targetId);
            benchMark.Dispose();
        }

        [Benchmark]
        public async Task FirstOrDefaultOnListAsync()
        {
            MovieDbContextTest benchMark = new();
            var results = await benchMark.GetMoviesAsListAsync();
            var first = results.FirstOrDefault(x => x.ID == targetId);
            benchMark.Dispose();
        }
        #endregion

        #region SingleOrDefaultTests
        [Benchmark]
        public void SingleOrDefaultOnIquerayble()
        {
            MovieDbContextTest benchMark = new();
            var results = benchMark.GetMoviesAsIQuerayble();
            var first = results.SingleOrDefault(x => x.ID == targetId);
            benchMark.Dispose();
        }

        [Benchmark]
        public void SingleOrDefaultOnList()
        {
            MovieDbContextTest benchMark = new();
            var results = benchMark.GetMoviesAsList();
            var first = results.SingleOrDefault(x => x.ID == targetId);
            benchMark.Dispose();
        }

        [Benchmark]
        public async Task SingleOrDefaultOnIqueraybleAsync()
        {
            MovieDbContextTest benchMark = new();
            var results = await benchMark.GetMoviesAsIQueraybleAsync();
            var first = results.SingleOrDefaultAsync(x => x.ID == targetId);
            benchMark.Dispose();
        }

        [Benchmark]
        public async Task SingleOrDefaultOnListAsync()
        {
            MovieDbContextTest benchMark = new();
            var results = await benchMark.GetMoviesAsListAsync();
            var first = results.SingleOrDefault(x => x.ID == targetId);
            benchMark.Dispose();
        }
        #endregion

    }

    public class MovieDbContextTest : IDisposable
    {
        private readonly MovieDbContext movieDbContext;

        public MovieDbContextTest()
        {
            DbContextOptionsBuilder<MovieDbContext> builder = new();
            builder
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .UseInMemoryDatabase(databaseName:$"FakeMovies{Guid.NewGuid()}");
            movieDbContext = new MovieDbContext(builder.Options);
            movieDbContext.Database.EnsureDeleted();
            movieDbContext.Database.EnsureCreated();
            SeedData();
        }

        public IQueryable<Movie> GetMoviesAsIQuerayble()
        {
            return movieDbContext.Movies;
        }
        public IList<Movie> GetMoviesAsList()
        {
            return movieDbContext.Movies.ToList();
        }
        public async Task<IQueryable<Movie>> GetMoviesAsIQueraybleAsync()
        {
            return await Task.FromResult(movieDbContext.Movies);
        }
        public async Task<IList<Movie>> GetMoviesAsListAsync()
        {
            return await movieDbContext.Movies.ToListAsync();
        }
        private void SeedData()
        {
            var fakemovies = Enumerable.Range(1, 2000).Select( id => new Movie { ID = id, ReleaseDate = DateTime.Now}).ToList();
            
            movieDbContext.Movies.AddRange(fakemovies);
            movieDbContext.SaveChanges();
        }

        public void Dispose()
        {
            movieDbContext.Database.EnsureDeleted();
            movieDbContext.Dispose();
        }
    }
}

