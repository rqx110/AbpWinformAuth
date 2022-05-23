using System.Threading.Tasks;

namespace AbpWinformAuth.Data;

public interface IAbpWinformAuthDbSchemaMigrator
{
    Task MigrateAsync();
}
