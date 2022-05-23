using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpWinformAuth.Data;

/* This is used if database provider does't define
 * IAbpWinformAuthDbSchemaMigrator implementation.
 */
public class NullAbpWinformAuthDbSchemaMigrator : IAbpWinformAuthDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
