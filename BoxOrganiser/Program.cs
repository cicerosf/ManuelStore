using BoxOrganiser.API.Startup.Authentication;
using BoxOrganiser.API.Startup.Pipeline;
using BoxOrganiser.API.Startup.Services;
using BoxOrganiser.API.Startup.Swagger;

var builder = WebApplication.CreateBuilder(args);

ServiceConfiguration.AddServices(builder);
AuthenticationConfiguration.AddAuthentication(builder);
SwaggerConfiguration.AddSwagger(builder);

var app = builder.Build();
PipelineConfiguration.ConfigurePipeline(app);

app.Run();
