using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpWinformAuth.Data;
using Volo.Abp.DependencyInjection;

namespace AbpWinformAuth.EntityFrameworkCore;

public class EntityFrameworkCoreAbpWinformAuthDbSchemaMigrator
    : IAbpWinformAuthDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpWinformAuthDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpWinformAuthDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpWinformAuthDbContext>()
            .Database
            .MigrateAsync();
    }
}
