using Account.API;
using Shared.Infrastructure;

namespace DogHub.API.Bootstrapper;

internal static class Extensions
{
    public static IServiceCollection AddModules(this IServiceCollection services)
    {
        services.AddAccount();

        return services;
    } 

    public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services)
    {
        services.AddInfrastructure();
        services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

        return services;
    } 

    public static IApplicationBuilder UseInfrastructureConfiguration(this IApplicationBuilder app)
    {
        app.UseInfrastructure();
        app.UseHttpsRedirection();

        return app;
    }
}
