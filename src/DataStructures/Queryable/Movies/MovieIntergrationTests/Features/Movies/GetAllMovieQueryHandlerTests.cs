namespace MovieIntergrationTests.Features.Movies;

public class GetAllMovieQueryHandlerTests : IClassFixture<MovieDbContextFixture>
{
    #region helpful links
    //https://www.youtube.com/watch?v=C4hvWJqju7s
    //https://docs.microsoft.com/en-us/ef/core/testing/testing-without-the-database#inmemory
    // https://www.youtube.com/watch?v=7roqteWLw4s
    // https://dev.to/mpetrinidev/combine-xunit-with-fluent-assertions-jli
    // https://anthonygiretti.com/2018/01/19/code-reliability-unit-testing-with-xunit-and-fluentassertions-in-net-core-2-apps/
    // https://devblogs.microsoft.com/devops/taking-the-mstest-framework-forward-with-mstest-v2/
    #endregion

    private readonly MovieDbContextFixture Fixture;

    public GetAllMovieQueryHandlerTests(MovieDbContextFixture fixture)
    {
        Fixture = fixture;
    }
    [Fact]
    public async Task GetAllQueryShouldHaveData()
    {
        //Arrange
        Fixture.LoadTestData();
        var sut = new GetAllMovieQueryHandler(Fixture.movieDbContext);
        //Act
        IQueryable<Movie> result = await sut.Handle(new GetAllMoviesQuery(), cancellationToken: default);
        //Assert
        result.Should().NotBeEmpty();
    }
}

