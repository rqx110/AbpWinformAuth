using System;
using System.Collections.Generic;
using System.Text;
using AbpWinformAuth.Localization;
using Volo.Abp.Application.Services;

namespace AbpWinformAuth;

/* Inherit your application services from this class.
 */
public abstract class AbpWinformAuthAppService : ApplicationService
{
    protected AbpWinformAuthAppService()
    {
        LocalizationResource = typeof(AbpWinformAuthResource);
    }
}
