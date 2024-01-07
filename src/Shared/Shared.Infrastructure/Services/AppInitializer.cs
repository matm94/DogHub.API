﻿using Microsoft.Extensions.Hosting;

namespace Shared.Infrastructure;

internal class AppInitializer : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<AppInitializer> _logger;
    public AppInitializer(IServiceProvider serviceProvider, ILogger<AppInitializer> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var dbContextTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => typeof(DbContext).IsAssignableFrom(x) && !x.IsInterface && x != typeof(DbContext));
        
        using var scope = _serviceProvider.CreateScope();

        foreach (var dbContextType in dbContextTypes)
        {
            var dbContext = scope.ServiceProvider.GetRequiredService(dbContextType) as DbContext;
            
            if (dbContext is null)
                continue;

            await dbContext.Database.MigrateAsync(cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}