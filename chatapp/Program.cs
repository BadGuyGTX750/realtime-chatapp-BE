using chatapp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure (Repositories, Services, etc...)
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
