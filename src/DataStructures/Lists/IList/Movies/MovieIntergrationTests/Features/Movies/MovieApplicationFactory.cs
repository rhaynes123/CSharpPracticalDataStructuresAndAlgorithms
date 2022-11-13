using System;
using Bogus;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Movies.Data;
using Movies.Features.Models;
using Movies.Features.Models.Enums;

namespace MovieIntegrationTests.Features.Movies;

// https://www.youtube.com/watch?v=ZTWl2s8ScMc
//https://stackoverflow.com/questions/54264787/unit-testing-with-ef-core-and-in-memory-database
//https://putridparrot.com/blog/auto-generating-test-data-with-bogus/
//https://khalidabuhakmeh.com/seed-entity-framework-core-with-bogus
//https://www.youtube.com/watch?v=AXu_5UBG2Qk&t=173s
// https://stackoverflow.com/questions/70982483/asp-net-core-integration-tests-with-dotnet-testcontainers
public class MovieApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    private readonly MySqlTestcontainer _dbtestContainers;
    public MovieApplicationFactory()
    {
        _dbtestContainers = new TestcontainersBuilder<MySqlTestcontainer>()
                 .WithDatabase(new MySqlTestcontainerConfiguration("mysql:8.0")
                 {
                     Database = Guid.NewGuid().ToString(),
                     Password = string.Empty,
                 })
                 .Build();
    }
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // base.ConfigureWebHost(builder);
        IEnumerable<KeyValuePair<string, string>> testSettings = new KeyValuePair<string, string>[]
        {
            new KeyValuePair<string,string>("ConnectionStrings:Movies",_dbtestContainers.ConnectionString),
        };

        IConfiguration testConfig = new ConfigurationBuilder()
           .AddInMemoryCollection(testSettings)
           .Build();

        builder.UseConfiguration(testConfig);
        builder.ConfigureTestServices(testServices =>
        {
            
            //testServices.RemoveAll(typeof(MovieDbContext));
            string testConnectionString = _dbtestContainers.ConnectionString;
            testServices.AddMediator(options: options => options.ServiceLifetime = ServiceLifetime.Scoped);
            testServices.AddScoped(scopedServices =>
            {
                return new DbContextOptionsBuilder<MovieDbContext>()
                .UseMySql(testConnectionString, ServerVersion.AutoDetect(testConnectionString))
                .EnableDetailedErrors()
                .EnableSensitiveDataLogging()
                .UseApplicationServiceProvider(scopedServices)
                .Options;
            });
            testServices.AddDbContext<MovieDbContext>(options => options.UseMySql(_dbtestContainers.ConnectionString, ServerVersion.AutoDetect(testConnectionString)));
            
        });
    }

    public async Task InitializeAsync()
    {
        await _dbtestContainers.StartAsync();
    }

    public new async Task DisposeAsync()
    {
        await _dbtestContainers.StopAsync();
    }
}
