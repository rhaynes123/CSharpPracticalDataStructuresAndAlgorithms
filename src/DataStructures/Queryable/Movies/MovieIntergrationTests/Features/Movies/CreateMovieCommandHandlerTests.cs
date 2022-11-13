using System;
namespace MovieIntegrationTests.Features.Movies
{
    public class CreateMovieCommandHandlerTests 
    {
        private readonly MovieApplicationFactory movieApplicationFactory;
        public CreateMovieCommandHandlerTests(MovieDbContextFixture fixture)
        {
            movieApplicationFactory = new MovieApplicationFactory<Program>();
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
            var sut = new CreateMovieCommandHandler(contextfixture.movieDbContext);
            //Act
            var result = await sut.Handle(createMovieCommand, default);
            //Assert
            contextfixture.movieDbContext
                .Movies
                .Should()
                .HaveCountGreaterThan(0);
        }
    }
}

