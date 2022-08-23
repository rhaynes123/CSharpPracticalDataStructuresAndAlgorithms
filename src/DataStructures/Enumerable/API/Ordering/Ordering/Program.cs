using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors( options =>
{
    options.AddPolicy( name: "AllowedUrls", builder =>
    {
        builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowedUrls");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseHttpsRedirection();

// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0
// https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-javascript?view=aspnetcore-6.0
// https://nodogmablog.bryanhogan.net/2022/04/a-simple-cors-example-with-a-net-6-web-api-application-and-a-net-6-web-application/
app.MapPost("/Saveorder", [EnableCors("AllowedUrls")] (Cart cart) =>
{
    return Results.Created("/Order",cart);
});

app.Run();

record Cart()
{
    [JsonPropertyName("cart")]
    public IEnumerable<CartItem>? cart { get; init; }
}

record CartItem()
{
    [JsonPropertyName("id")]
    public int? id { get; init; }
    [JsonPropertyName("item")]
    public Item Item { get; init; }
}
record Item()
{
    [JsonPropertyName("id")]
    public int? Id { get; init; }
    [JsonPropertyName("name")]
    public string? Name { get; init; } = default!;
    [JsonPropertyName("price")]
    public decimal? Price { get; init; }
}
