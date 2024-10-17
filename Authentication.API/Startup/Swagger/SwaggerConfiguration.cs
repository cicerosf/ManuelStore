namespace Authentication.API.Startup.Swagger;

public static class SwaggerConfiguration
{
    public static void AddSwagger(WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}
