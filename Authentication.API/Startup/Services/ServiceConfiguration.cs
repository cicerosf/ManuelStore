using Authentication.API.Application.Services;
using Authentication.API.Domain.Interfaces;

namespace Authentication.API.Startup.Services;

public static class ServiceConfiguration
{
    public static void AddServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        builder.Services.AddControllers();
    }
}
