using Shared.Infrastructure;

[assembly: InternalsVisibleTo("Account.API")]
namespace Account.Core;

internal static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddMSSQL<AccountDbContext>();
        return services;
    }
}
 