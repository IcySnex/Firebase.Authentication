using Firebase.Authentication.Requests;
using Firebase.Authentication.Sample.WinForms.Helpers;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Firebase.Authentication.Sample.WinForms.Controls;

public partial class HomeControl : UserControl
{
    ILogger logger = Program.LoggerFactory.CreateLogger<HomeControl>();

    public HomeControl()
    {
        InitializeComponent();

        Navigate(new ProviderControl(this));
    }


    public void Navigate(
        Control control)
    {
        ContentPanel.Controls.Clear();
        ContentPanel.Controls.Add(control);

        logger.LogInformation("[HomeControl-Navigate] Navigated to control");
    }


    CancellationTokenSource? cancelSource;

    public async Task<bool> SignInAsync(
        SignInRequest request)
    {
        try
        {
            cancelSource = Program.Configuration.Timeout is null ? new() : new(Program.Configuration.Timeout.Value);
            await Program.Authentication.SignInAsync(request, cancelSource.Token);

            Program.MainForm.Navigate(new UserInfoControl());
            Program.MainForm.HomeButton.Visible = false;
            Program.MainForm.UserInfoButton.Visible = true;
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Signing in failed", "HomeControl-SignUpAsync");
        }
        return false;
    }

    public async Task<bool> SignUpAsync(
        SignUpRequest request)
    {
        try
        {
            cancelSource = Program.Configuration.Timeout is null ? new() : new(Program.Configuration.Timeout.Value);
            await Program.Authentication.SignUpAsync(request, cancelSource.Token);

            Program.MainForm.Navigate(new UserInfoControl());
            Program.MainForm.HomeButton.Visible = false;
            Program.MainForm.UserInfoButton.Visible = true;
            return true;
        }
        catch (TaskCanceledException) { }
        catch (Exception ex)
        {
            logger.LogErrorAndShow(ex, "Signing up failed", "HomeControl-SignUpAsync");
        }
        return false;
    }


    private void NoticeLink1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
        Process.Start(new ProcessStartInfo()
        {
            FileName = "https://cloud.google.com/terms/",
            UseShellExecute = true,
            CreateNoWindow = true
        });


    private void NoticeLink2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
        Process.Start(new ProcessStartInfo()
        {
            FileName = "https://cloud.google.com/terms/cloud-privacy-notice",
            UseShellExecute = true,
            CreateNoWindow = true
        });
}