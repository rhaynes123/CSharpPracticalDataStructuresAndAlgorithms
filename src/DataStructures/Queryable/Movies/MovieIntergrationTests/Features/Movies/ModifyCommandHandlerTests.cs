using System;
using Microsoft.EntityFrameworkCore;

namespace MovieIntergrationTests.Features.Movies
{
    public class ModifyCommandHandlerTests :IClassFixture<MovieDbContextFixture>
    {
        private readonly MovieDbContextFixture contextFixture;
        public ModifyCommandHandlerTests(MovieDbContextFixture fixture)
        {
            contextFixture = fixture;
        }
        [Fact]
        public async Task ModifyCommandShouldAlterData()
        {
            //Arrange
            var modifiedDate = new DateTime(2005, 06, 15);
            var newMovie = new Movie
            {
                ID = 1,
                Title = "Batman Begins",
                ReleaseDate = new DateTime(2005, 05, 15)
            };
            var createMovieCommand = new CreateMovieCommand(newMovie);
            var createhandler = new CreateMovieCommandHandler(contextFixture.movieDbContext);
            var sut = new ModifyMovieCommandHandler(contextFixture.movieDbContext);
            //Act
            var createResult = await createhandler.Handle(createMovieCommand, default);
            var target = await contextFixture.movieDbContext
                .Movies
                .FirstOrDefaultAsync( movie => movie.ID == newMovie.ID);
            target!.ReleaseDate = modifiedDate;
            var modifyResult = await sut.Handle(new ModifyMovieCommand(target!), default);
            //Assert
            modifyResult.ReleaseDate.Should().BeSameDateAs(modifiedDate);
        }
    }
}

