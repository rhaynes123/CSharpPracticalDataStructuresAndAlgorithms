using Microsoft.EntityFrameworkCore;
using RichsRack.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString("Snacks") ?? throw new ArgumentNullException("connectionstring");
builder.Services.AddRazorPages();
builder.Services.AddMediator(options =>
{
    options.ServiceLifetime = ServiceLifetime.Scoped;
});
builder.Services.AddDbContext<SnacksDbContext>((serviceProvider, optionsBuilder) =>
{
    optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), optionsBuilder => optionsBuilder
        .EnableRetryOnFailure(maxRetryCount: 3, maxRetryDelay: TimeSpan.FromSeconds(10), errorNumbersToAdd: null));

    optionsBuilder.EnableDetailedErrors();
    optionsBuilder.EnableSensitiveDataLogging();
});
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Cache");
    options.InstanceName = "Snacks";
});
var app = builder.Build();
using (var serviceScope = app.Services.CreateScope())
{
    SnacksDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<SnacksDbContext>();
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

