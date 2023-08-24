using Firebase.Authentication.WPF.Configuration;
using Firebase.Authentication.WPF.ProviderFlows;
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
    }


    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await SignInWithGoogleAsync();
    }


    public async Task SignInWithGoogleAsync()
    {
        AuthenticationConfig config = new("AIzaSyALFTcLBy2mjtgCjKfIJ82Ivu-wVR3w9Z4");
        WindowConfig windowConfig = new("Sign in!");

        IAuthenticationClient authentication = new AuthenticationClient(config);
        IProviderFlow flow = new GoolgeProviderFlow(windowConfig);
        
        SignInRequest request = SignInRequest.WithProviderFlow(flow);
        await authentication.SignInAsync(request);

        Result.Text = authentication.CurrentUser?.Email ?? "oops";
    }
}