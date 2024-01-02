using Account.Core;

[assembly: InternalsVisibleTo("DogHub.API.Bootstrapper")]
namespace Account.API;

internal static class Extensions
{
    public static IServiceCollection AddAccount(this IServiceCollection services)
    {
        services.AddCore();

        return services;
    }
}