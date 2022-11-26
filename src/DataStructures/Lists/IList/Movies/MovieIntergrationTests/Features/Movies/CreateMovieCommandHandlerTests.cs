using System;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data;
using Movies.Features.Movies;
using Movies.Features.Movies.Models;

namespace MovieIntegrationTests.Features.Movies
{
    public class CreateMovieCommandHandlerTests: IClassFixture<MovieApplicationFactory>
    {
        private readonly MovieApplicationFactory contextfixture;
        private readonly MovieDbContext movieDbContext;
        public CreateMovieCommandHandlerTests(MovieApplicationFactory movieApplicationFactory)
        {
            contextfixture = movieApplicationFactory;
            movieDbContext = contextfixture.DbContext;
        }

        [Fact]
        public async Task CreateCommandShouldSaveData()
        {
            //Arrange
            var newMovie = new Movie
            {
                ID = 1,
                Title = "Batman Begins",
                ReleaseDate = new DateTime(2005,06,15)
            };
            var createMovieCommand = new CreateMovieCommand(newMovie);
            var sut = new CreateMovieCommandHandler(movieDbContext);
            //Act
            await sut.Handle(createMovieCommand, default);
            //Assert
            movieDbContext
                .Movies
                .Should()
                .HaveCountGreaterThan(0);
        }
    }
}

