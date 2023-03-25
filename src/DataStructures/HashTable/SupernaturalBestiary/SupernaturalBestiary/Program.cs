using Microsoft.EntityFrameworkCore;
using SupernaturalBestiary.Data;
using SupernaturalBestiary.Infastructure.Options;
using SupernaturalBestiary.Infastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOptions<CosmosDbSettings>().
    Bind(builder.Configuration.GetSection("CosmosDb"))
    .ValidateDataAnnotations()
    .ValidateOnStart();



string key = builder.Configuration["CosmosDb:Key"];
string account = builder.Configuration["CosmosDb:Account"];
string database = builder.Configuration["CosmosDb:DatabaseName"];
builder.Services.AddScoped<ICreatureRepository, CreatureRepository>();
builder.Services.AddDbContext<CreatureDbContext>(options => options.UseCosmos(account, key, database));
builder.Services.AddRazorPages();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CreatureDbContext>();
    await context.Database.EnsureCreatedAsync();
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

