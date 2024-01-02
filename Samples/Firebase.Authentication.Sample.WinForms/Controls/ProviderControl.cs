using Firebase.Authentication.Requests;
using Firebase.Authentication.WinForms.UI;

namespace Firebase.Authentication.Sample.WinForms.Controls;

public partial class ProviderControl : UserControl
{
    readonly HomeControl homeControl;

    public ProviderControl(
        HomeControl homeControl)
    {
        InitializeComponent();

        this.homeControl = homeControl;
    }


    private void EmailButton_Click(object sender, EventArgs e) =>
        homeControl.Navigate(new EmailControl(homeControl));

    private void PhoneButton_Click(object sender, EventArgs e) =>
        homeControl.Navigate(new PhoneControl());


    private async void ProviderButton_Click(object sender, EventArgs e) =>
        await homeControl.SignInAsync(SignInRequest.WithProviderFlow(((FirebaseAuthenticationButton)sender).ImageKey switch
        {
            "Facebook" => Program.FacebookFlow,
            "Google" => Program.GoogleFlow,
            "Apple" => Program.AppleFlow,
            "Github" => Program.GithubFlow,
            "Twitter" => Program.TwitterFlow,
            "Microsoft" => Program.MicrosoftFlow,
            "Yahoo" => Program.YahooFlow,
            _ => default!
        }));


    private async void GuestButton_Click(object sender, EventArgs e) =>
        await homeControl.SignUpAsync(SignUpRequest.Anonymously());
}