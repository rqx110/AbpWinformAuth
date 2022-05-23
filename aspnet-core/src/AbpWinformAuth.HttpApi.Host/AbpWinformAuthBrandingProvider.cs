using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpWinformAuth;

[Dependency(ReplaceServices = true)]
public class AbpWinformAuthBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpWinformAuth";
}
