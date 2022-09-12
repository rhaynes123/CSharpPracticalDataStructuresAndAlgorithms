
using System;
using System.Security.Policy;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;

namespace MovieIntegrationTests.Pages
{
    public class IndexPageTests: IClassFixture<MovieWebApplicationFactory>
    {
        // https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
        // https://www.codeguru.com/csharp/web-automation-testing-using-selenium-with-microsoft-net-framework/
        // https://www.benday.com/2021/07/19/asp-net-core-integration-tests-with-selenium-webapplicationfactory/
        // https://blog-bertrand-thomas.devpro.fr/2020/01/27/fix-breaking-change-asp-net-core-3-integration-tests-selenium/
        // https://scotthannen.org/blog/2021/11/18/testserver-how-did-i-not-know.html

        private readonly MovieWebApplicationFactory Factory;

        private HttpClient Client { get; set; }
        private IWebDriver Driver;
        private WebDriverWait Wait;
        public IndexPageTests(MovieWebApplicationFactory applicationFactory)
        {
            Factory = applicationFactory;
            Client = Factory.CreateClient();
            Driver = new ChromeDriver();
        }
        [Fact]
        public async Task IndexLoadsOkStatusAsync()
        {
            //Arrange
            //Act
            var response = await Client.GetAsync("/Index");
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            //Assert
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType!.ToString());
        }
        
        [Fact (Skip ="Currently in the process of understanding how to start the web host correctly so the pages can navigate to the url")]
        public async Task IndexLoadOnGetAsync()
        {
            // Arrange


            // Act
            var response = await Client.GetAsync("/Index");
            var stringResponse = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            string requestUri = response.RequestMessage.RequestUri.ToString();
            try
            {
               
                Driver.Navigate().GoToUrl(requestUri);
                Driver.Manage().Window.Maximize();
                Thread.Sleep(TimeSpan.FromSeconds(10));
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
                Driver.Quit();
            }
            // Assert

            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType!.ToString());
            Driver.Quit();
        }
    }
}

