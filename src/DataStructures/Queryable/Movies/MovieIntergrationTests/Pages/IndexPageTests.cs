using System;
using System.Security.Policy;

namespace MovieIntergrationTests.Pages
{
    public class IndexPageTests: IClassFixture<MovieWebApplicationFactory>
    {
        // https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0

        private readonly MovieWebApplicationFactory factory;

        private HttpClient Client { get; set; }
        public IndexPageTests(MovieWebApplicationFactory applicationFactory)
        {
            factory = applicationFactory;
            Client = factory.CreateClient();
        }

        [Fact]
        public async Task IndexLoadOnGetAsync()
        {
            // Arrange
            

            // Act
            var response = await Client.GetAsync("/Index");
            var stringResponse = await response.Content.ReadAsStringAsync();
            //Assert.Contains("/basket/update", updateResponse.RequestMessage.RequestUri.ToString());
            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType!.ToString());
        }
    }
}

