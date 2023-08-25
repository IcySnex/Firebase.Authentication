using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.Flows;
using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;
using System.Windows;

namespace Firebase.Authentication.Sample.WPF;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();


        AuthenticationConfig config = new("AIzaSyALFTcLBy2mjtgCjKfIJ82Ivu-wVR3w9Z4");
        WindowConfig windowConfig = new(
            title: "Sign in!",
            owner: this,
            startupLocation: WindowStartupLocation.CenterOwner,
            left: 100,
            showAsDialog: true);

        authentication = new AuthenticationClient(config);
        flow = new FacebookProviderFlow(windowConfig);

    }


    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await LinkToProviderAsync();
    }


    IAuthenticationClient authentication;
    IProviderFlow flow;

    public async Task SignInWithProviderAsync()
    {
        try
        {
            SignInRequest request = SignInRequest.WithProviderFlow(flow);
            await authentication.SignInAsync(request);

            Result.Text = authentication.CurrentUser?.Email ?? "nu email";
        }
        catch (Exception ex)
        {
            Result.Text = "Signing in failed: " + ex.Message;
        }

    }

    public async Task LinkToProviderAsync()
    {
        try
        {
            SignInRequest request = SignInRequest.WithEmailPassword("my@email.com", "123456");
            await authentication.SignInAsync(request);
        }
        catch (Exception ex)
        {
            Result.Text = "Signing in failed: " + ex.Message;
            return;
        }

        try
        {
            LinkRequest request = LinkRequest.ToProviderFlow(flow);
            await authentication.LinkAsync(request);

            Result.Text = authentication.CurrentUser?.Email ?? "nu email";
        }
        catch (Exception ex)
        {
            Result.Text = "Linking failed: " + ex.Message;
        }

    }
}