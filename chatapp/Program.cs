using chatapp.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Swashbuckle.AspNetCore.SwaggerUI;


var builder = WebApplication.CreateBuilder(args);
// Add infrastructure (Repositories, Services, etc...)
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();
// Add all necesary config for the app (swagger, request pipeline, etc...)
app.UseConfiguration();

app.Run();
