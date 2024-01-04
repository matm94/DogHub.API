using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Abstractions;

// [assembly: InternalsVisibleTo("Shared.Abstractions")]
[assembly: InternalsVisibleTo("DogHub.API.Bootstrapper")]
namespace Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        services.AddSingleton<ITimeService, TimeService>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        return app;
    }
}
