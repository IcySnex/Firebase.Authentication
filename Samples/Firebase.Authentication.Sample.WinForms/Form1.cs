using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.WinForms.Flows;

namespace Firebase.Authentication.Sample.WinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private async void button1_Click(object sender, EventArgs e)
    {
        IProviderFlow flow = new YahooProviderFlow(new("ass", null!, this, FormStartPosition.CenterParent, 0, 0, true));
        IAuthenticationClient client = new AuthenticationClient(new AuthenticationConfig("AIzaSyALFTcLBy2mjtgCjKfIJ82Ivu-wVR3w9Z4"));

        try
        {
            await flow.SignInAsync(client, new CancellationTokenSource(10000).Token);
        } catch (Exception ex)
        {

        }
    }
}