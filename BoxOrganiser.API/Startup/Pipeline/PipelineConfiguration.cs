using BoxOrganiser.API.Middlewares;

namespace BoxOrganiser.API.Startup.Pipeline;

public static class PipelineConfiguration
{
    public static void ConfigurePipeline(WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
        else
        {
            app.UseHttpsRedirection();

        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
    }
}
