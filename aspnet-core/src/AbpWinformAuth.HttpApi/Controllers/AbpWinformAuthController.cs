using AbpWinformAuth.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace AbpWinformAuth.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AbpWinformAuthController : AbpControllerBase
{
    protected AbpWinformAuthController()
    {
        LocalizationResource = typeof(AbpWinformAuthResource);
    }
}
