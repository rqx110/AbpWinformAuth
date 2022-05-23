using IdentityModel;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IdentityModel;

namespace AbpWinformAuth.HttpApi.Client.WinformTestApp;

public partial class MainForm : Form, ITransientDependency
{
    private readonly IIdentityModelAuthenticationService _authenticationService;
    
    private readonly IProfileAppService _profileAppService;
    
    public MainForm(
        IIdentityModelAuthenticationService authenticationService,
        IProfileAppService profileAppService)
    {
        _authenticationService = authenticationService;
        _profileAppService = profileAppService;

        InitializeComponent();
    }

    private async void btnLogin_Click(object sender, EventArgs e)
    {
        var userName = txtUserName.Text;
        var password = txtPassword.Text;
        
        var configuration = new IdentityClientConfiguration(
            "https://localhost:44322",
            "AbpWinformAuth",
            "AbpWinformAuth_App",
            "1q2w3e*",
            OidcConstants.GrantTypes.Password,
            userName,
            password
        );
        
       AccessTokenUtil.AccessToken = await _authenticationService.GetAccessTokenAsync(configuration);
    }

    private async void btnCallRemote_Click(object sender, EventArgs e)
    {
        try
        {
            var output = await _profileAppService.GetAsync();
            
            MessageBox.Show($"UserName: {output.UserName}\n" +
                            $"Email: {output.Email}\n" +
                            $"Name: {output.Name}\n" +
                            $"Surname: {output.Surname}");
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
