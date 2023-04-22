using Microsoft.AspNetCore.Rewrite;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace chatapp.Infrastructure
{
    public static class AppConfiguration
    {
        public static WebApplication UseConfiguration(this WebApplication app)
        {
            // Use swagger UI
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

            // Configure the HTTP request pipeline.
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
