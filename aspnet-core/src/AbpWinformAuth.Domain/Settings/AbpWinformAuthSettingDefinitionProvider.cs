using Volo.Abp.Settings;

namespace AbpWinformAuth.Settings;

public class AbpWinformAuthSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpWinformAuthSettings.MySetting1));
    }
}
