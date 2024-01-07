namespace Shared.Infrastructure;

public static class MSSQLExtensions
{
    public static IServiceCollection AddMSSQL(this IServiceCollection services)
    {
        var options = services.GetOptions<MSSQLOptions>("mssql");

        services.AddSingleton(options);

        return services;
    }

    public static IApplicationBuilder UseMSSQL(this IApplicationBuilder app)
    {
        return app;
    }

    public static IServiceCollection AddMSSQL<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<MSSQLOptions>("mssql");
        
        services.AddDbContext<T>(x => x.UseSqlServer(options.ConnectionString));

        return services;
    }
}
