using IdentityModel.Client;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.Authentication;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.IdentityModel;

namespace AbpWinformAuth.HttpApi.Client.WinformTestApp;

[Dependency(ReplaceServices = true)]
public class MyIdentityModelRemoteServiceHttpClientAuthenticator : IdentityModelRemoteServiceHttpClientAuthenticator
{
    private readonly IDistributedCache<IdentityModelTokenCacheItem> _tokenCache;
    private readonly IRemoteServiceConfigurationProvider _remoteServiceConfigurationProvider;
    
    public MyIdentityModelRemoteServiceHttpClientAuthenticator(
        IIdentityModelAuthenticationService identityModelAuthenticationService, 
        IDistributedCache<IdentityModelTokenCacheItem> tokenCache, 
        IRemoteServiceConfigurationProvider remoteServiceConfigurationProvider) 
        : base(identityModelAuthenticationService)
    {
        _tokenCache = tokenCache;
        _remoteServiceConfigurationProvider = remoteServiceConfigurationProvider;
    }

    public override async Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
    {
        if (context.RemoteService.GetUseCurrentAccessToken() != false)
        {
            var accessToken = GetAccessTokenOrNullAsync();
            if (accessToken != null)
            {
                context.Request.SetBearerToken(accessToken);
                return;
            }
        }

        await base.Authenticate(context);
    }
    
    protected virtual string GetAccessTokenOrNullAsync()
    {
        return AccessTokenUtil.AccessToken;
    }
}