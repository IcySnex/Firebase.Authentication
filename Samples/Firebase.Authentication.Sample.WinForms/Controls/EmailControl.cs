using Firebase.Authentication.Models;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WinForms.Helpers;
using Firebase.Authentication.Types;
using Microsoft.Extensions.Logging;

namespace Firebase.Authentication.Sample.WinForms.Controls;

public partial class EmailControl : UserControl
{
    ILogger logger = Program.LoggerFactory.CreateLogger<EmailControl>();

    readonly HomeControl homeControl;

    public EmailControl(
        HomeControl homeControl)
    {
        InitializeComponent();

        this.homeControl = homeControl;
        SetDefaultMode();
    }

    void SetDefaultMode()
    {
        DisplayNamePanel.Visible = false;
        PasswordPanel.Visible = false;
        ForgotPasswordLink.Visible = false;

        EmailPanel.Location = new(106, 116);
        CancelButton.Location = new(106, 184);
        SignInButton.Location = new(262, 184);

        SignInButton.Text = "Sign in";
    }

    void SetSignUpMode()
    {
        DisplayNamePanel.Visible = true;
        PasswordPanel.Visible = true;
        ForgotPasswordLink.Visible = false;

        EmailPanel.Location = new(106, 50);
        DisplayNamePanel.Location = new(106, 110);
        PasswordPanel.Location = new(106, 170);
        CancelButton.Location = new(106, 257);
        SignInButton.Location = new(262, 257);

        SignInButton.Text = "Sign up";
    }

    void SetSignInMode()
    {
        DisplayNamePanel.Visible = false;
        PasswordPanel.Visible = true;
        ForgotPasswordLink.Visible = true;

        EmailPanel.Location = new(106, 70);
        PasswordPanel.Location = new(106, 130);
        ForgotPasswordLink.Location = new(106, 189);
        CancelButton.Location = new(106, 251);
        SignInButton.Location = new(262, 251);

        SignInButton.Text = "Sign in";
    }


    private void CancelButton_Click(object sender, EventArgs e) =>
        homeControl.Navigate(new ProviderControl(homeControl));


    private async void SignInButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EmailContent.Text))
        {
            logger.LogErrorAndShow("The email field cannot be empty.", "Signing up failed", "EmailViewModel-SignUpAsync");
            return;
        }
        if (!PasswordPanel.Visible)
        {
            await PrepareSignInAsync();
            return;
        }
        if (string.IsNullOrWhiteSpace(PasswordContent.Text))
        {
            logger.LogErrorAndShow("The password field cannot be empty.", "Signing up failed", "EmailViewModel-SignUpAsync");
            return;
        }

        await (DisplayNamePanel.Visible ?
            homeControl.SignUpAsync(SignUpRequest.WithEmailPassword(EmailContent.Text, PasswordContent.Text, DisplayNameContent.Text)) :
            homeControl.SignInAsync(SignInRequest.WithEmailPassword(EmailContent.Text, PasswordContent.Text)));
    }


    async Task PrepareSignInAsync()
    {
        try
        {
            SignInMethod method = await Program.Authentication.GetSignInMethodAsync(EmailContent.Text);
            if (!method.IsRegistered)
            {
                SetSignUpMode();
                return;
            }
            if (method.Providers is null)
            {
                logger.LogErrorAndShow("This account only supports signing in via an email link, which is not supported by this application.", "Signing up failed", "EmailViewModel-PrepareSignInAsync");
                return;
            }
            if (method.Providers.Contains(Provider.EmailAndPassword))
            {
                SetSignInMode();
                return;
            }

            logger.LogErrorAndShow("This account only supports signing in via one of these providers: " + string.Join(", ", method.Providers), "Signing up failed", "EmailViewModel-PrepareSignInAsync");
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Signing up failed", "EmailViewModel-PrepareSignInAsync");
        }
    }



    private async void ForgotPasswordLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(EmailContent.Text))
        {
            logger.LogErrorAndShow("The email field can not be empty", "Resetting password failed", "EmailControl-ForgotPasswordLink_LinkClicked");
            return;
        }

        if (MessageBox.Show("If you continue a 'reset password' mail will be sent to your account and all of your linked sign-in methods will be removed.\nDo you want to continue?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            return;

        try
        {
            await Program.Authentication.SendEmailAsync(EmailRequest.ResetPassword(EmailContent.Text));
        }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Resetting password failed", "EmailControl-ForgotPasswordLink_LinkClicked");
        }
    }
}