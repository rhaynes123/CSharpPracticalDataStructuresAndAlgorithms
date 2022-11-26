using System.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Data.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string mySqlConnectionString = builder.Configuration.GetConnectionString("Movies")!;
RedisSettings redisSettings = new RedisSettings();
builder.Configuration.GetSection("Redis").Bind(redisSettings);
builder.Services.AddRazorPages();
builder.Services.AddMediator( options: options => options.ServiceLifetime = ServiceLifetime.Scoped);
builder.Services.AddSingleton<RedisSettings>(redisSettings);

builder.Services.AddDbContext<MovieDbContext>( (serviceProvider, optionsBuilder) =>
{
    optionsBuilder.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString), optionsBuilder => optionsBuilder
        .EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null));
        
    optionsBuilder.EnableDetailedErrors();
    optionsBuilder.EnableSensitiveDataLogging();
});
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Cache");
    options.InstanceName = "Movies";
});
var app = builder.Build();
using (var serviceScope = app.Services.CreateScope())
{
    MovieDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<MovieDbContext>();
    await dbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

public partial class Program { }