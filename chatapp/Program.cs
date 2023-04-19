using chatapp.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Rewrite;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add infrastructure (Repositories, Services, etc...)
builder.Services.AddInfrastructure(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "StefanBeam API V1 Docs");
        options.DocExpansion(DocExpansion.None);
        options.DefaultModelsExpandDepth(-1); 
    });
    // Redirect to swagger page on application start
    var option = new RewriteOptions();
    option.AddRedirect("^$", "swagger");
    app.UseRewriter(option);
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.Run();
