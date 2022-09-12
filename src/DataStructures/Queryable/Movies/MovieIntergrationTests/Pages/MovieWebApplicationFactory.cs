using System;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MediatR;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using OpenQA.Selenium;
using Microsoft.AspNetCore.TestHost;

namespace MovieIntegrationTests.Pages
{
    public class MovieWebApplicationFactory: WebApplicationFactory<Program>
    {
        // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1?view=aspnetcore-6.0
        // https://lee-jdale.medium.com/testing-in-net-with-webapplicationfactory-including-minimal-apis-ddcb4ed0aef5
        // https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0
        // https://github.com/dotnet-architecture/eShopOnWeb/blob/main/tests/FunctionalTests/Web/WebTestFixture.cs
        // https://visualstudiomagazine.com/articles/2017/07/01/testserver.aspx
        public TestServer testServer;
        public MovieWebApplicationFactory()
        {
           
        }

        protected override Microsoft.AspNetCore.Hosting.IWebHostBuilder? CreateWebHostBuilder()
        {
            return base.CreateWebHostBuilder();
        }
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseEnvironment("Development");
            builder.ConfigureServices(services =>
            {
                services.AddScoped(scopedServices =>
                {
                    return new DbContextOptionsBuilder<MovieDbContext>()
                    .UseInMemoryDatabase("TestingDb")
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
                    .UseApplicationServiceProvider(scopedServices)
                    .Options;
                });
                services.AddMediatR(typeof(Program));
            });
            return base.CreateHost(builder);
        }
    }
}

