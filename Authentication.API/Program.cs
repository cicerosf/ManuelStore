using Authentication.API.Startup.Pipeline;
using Authentication.API.Startup.Services;
using Authentication.API.Startup.Swagger;

var builder = WebApplication.CreateBuilder(args);

ServiceConfiguration.AddServices(builder);
SwaggerConfiguration.AddSwagger(builder);

var app = builder.Build();

PipelineConfiguration.ConfigurePipeline(app);

app.Run();