using System;
using Bogus;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Movies.Data;
using Movies.Features.Movies.Models;
using Movies.Features.Movies.Models.Enums;
using MySqlConnector;

namespace MovieIntegrationTests.Features.Movies;

#region
// https://www.youtube.com/watch?v=ZTWl2s8ScMc
//https://stackoverflow.com/questions/54264787/unit-testing-with-ef-core-and-in-memory-database
//https://putridparrot.com/blog/auto-generating-test-data-with-bogus/
//https://khalidabuhakmeh.com/seed-entity-framework-core-with-bogus
//https://www.youtube.com/watch?v=AXu_5UBG2Qk&t=173s
// https://stackoverflow.com/questions/70982483/asp-net-core-integration-tests-with-dotnet-testcontainers
// https://mysqlconnector.net/tutorials/connect-to-mysql/
// https://www.azureblue.io/asp-net-core-integration-tests-with-test-containers-and-postgres/
#endregion
public class MovieApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    public readonly MySqlTestcontainer _dbtestContainers;
    public MovieDbContext DbContext;
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
        IEnumerable<KeyValuePair<string, string?>> testSettings = new KeyValuePair<string, string?>[]
        {
            new KeyValuePair<string,string?>("ConnectionStrings:Movies",_dbtestContainers.ConnectionString),
        };

        IConfiguration testConfig = new ConfigurationBuilder()
           .AddInMemoryCollection(testSettings)
           .Build();

        builder.UseConfiguration(testConfig);
        builder.ConfigureTestServices(testServices =>
        {
            
            testServices.RemoveAll(typeof(MovieDbContext));
            string testConnectionString = _dbtestContainers.ConnectionString;
            testServices.AddMediator(options: options => options.ServiceLifetime = ServiceLifetime.Scoped);
            
            testServices.AddDbContext<MovieDbContext>(options => options.UseMySql(testConnectionString, ServerVersion.AutoDetect(testConnectionString)));
            // Ensure schema gets created
            var serviceProvider = testServices.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var scopedServices = scope.ServiceProvider;
            var context = scopedServices.GetRequiredService<MovieDbContext>();
            context.Database.EnsureCreated();
            var fakemovies = Enumerable.Range(1, 5).Select(id =>
            {
                var random = new Random();
                Genre randomGenre = (Genre)random.Next(1, 5);
                return new Movie { ID = id, Genre = randomGenre, ReleaseDate = DateTime.Now };
            }).ToList();

            context.Movies.AddRange(fakemovies);
            context.SaveChanges();
            this.DbContext = context;
            
            //context.Database.EnsureCreated();
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
