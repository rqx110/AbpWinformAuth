using AbpWinformAuth.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpWinformAuth.Permissions;

public class AbpWinformAuthPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AbpWinformAuthPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(AbpWinformAuthPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpWinformAuthResource>(name);
    }
}
