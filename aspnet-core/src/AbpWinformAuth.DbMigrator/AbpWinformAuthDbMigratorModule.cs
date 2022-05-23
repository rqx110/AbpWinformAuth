using AbpWinformAuth.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpWinformAuth.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpWinformAuthEntityFrameworkCoreModule),
    typeof(AbpWinformAuthApplicationContractsModule)
    )]
public class AbpWinformAuthDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
