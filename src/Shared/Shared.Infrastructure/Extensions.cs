[assembly: InternalsVisibleTo("DogHub.API.Bootstrapper")]
namespace Shared.Infrastructure;

internal static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddErrorHandling();

        services.AddSingleton<ITimeService, TimeService>();

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseErrorHandling();

        return app;
    }
}
