using Volo.Abp.Modularity;

namespace AbpWinformAuth;

[DependsOn(
    typeof(AbpWinformAuthApplicationModule),
    typeof(AbpWinformAuthDomainTestModule)
    )]
public class AbpWinformAuthApplicationTestModule : AbpModule
{

}
