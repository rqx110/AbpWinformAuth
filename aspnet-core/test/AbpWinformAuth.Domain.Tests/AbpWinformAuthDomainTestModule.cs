using AbpWinformAuth.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpWinformAuth;

[DependsOn(
    typeof(AbpWinformAuthEntityFrameworkCoreTestModule)
    )]
public class AbpWinformAuthDomainTestModule : AbpModule
{

}
