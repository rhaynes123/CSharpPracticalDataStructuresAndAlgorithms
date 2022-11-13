using System.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Movies.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddMediator( options: options => options.ServiceLifetime = ServiceLifetime.Scoped);
string mySqlConnectionString = builder.Configuration.GetConnectionString("Movies")!;


builder.Services.AddDbContext<MovieDbContext>(options =>
                options.UseMySql(
                    mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString),
                    options => options.EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null))
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging());
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