using System;
using DotNet.Testcontainers.Containers;
using MovieIntegrationTests.Features.Movies;
using MySqlConnector;
#region
// https://mysqlconnector.net/tutorials/connect-to-mysql/
// https://www.azureblue.io/asp-net-core-integration-tests-with-test-containers-and-postgres/
#endregion
namespace MovieIntergrationTests.Features.Movies
{
	public class MovieDbContextTests: IClassFixture<MovieApplicationFactory>
    {
		private readonly MovieApplicationFactory _testFactory;
        private readonly MySqlTestcontainer _dbtestContainers;
        public MovieDbContextTests(MovieApplicationFactory applicationFactory)
		{
			_testFactory = applicationFactory;
            _dbtestContainers = _testFactory._dbtestContainers;
		}
		[Fact]
		public async Task DatabaseExists()
		{
            //Arrange
            Int64 actual = 0;
            int expected = 1;
            using var connection = new MySqlConnection(_dbtestContainers.ConnectionString);
            //Act

            await connection.OpenAsync();
            using var command = new MySqlCommand("SELECT 1", connection);
            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                actual = (Int64)reader.GetValue(0);
            }
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}

