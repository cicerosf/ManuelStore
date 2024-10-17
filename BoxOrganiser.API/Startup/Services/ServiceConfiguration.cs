using BoxOrganiser.API.Application.Services;
using BoxOrganiser.API.Domain.Interfaces;
using BoxOrganiser.API.Infrastructure.Repositories;

namespace BoxOrganiser.API.Startup.Services;

public static class ServiceConfiguration
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IBoxRepository, BoxRepository>();
        builder.Services.AddScoped<IPackingService, PackingService>();
        builder.Services.AddControllers();
    }
}
