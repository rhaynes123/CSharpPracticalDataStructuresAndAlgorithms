using StatesApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGraphQLServer().AddQueryType<GetStatesQuery>();
var app = builder.Build();
app.UseRouting().UseEndpoints( endpoint => endpoint.MapGraphQL());
app.MapGet("/", () => "Graph is Awesome");

app.Run();

