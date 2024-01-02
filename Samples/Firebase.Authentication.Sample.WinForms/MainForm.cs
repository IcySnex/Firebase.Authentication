using Firebase.Authentication.Sample.WinForms.Controls;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Firebase.Authentication.Sample.WinForms;

public partial class MainForm : Form
{
    ILogger logger = Program.LoggerFactory.CreateLogger<MainForm>();

    public MainForm()
    {
        InitializeComponent();

        Navigate(new HomeControl());
    }


    public void Navigate(
        Control control)
    {
        ContentPanel.Controls.Clear();
        ContentPanel.Controls.Add(control);
        control.Location = new(control.Location.X, (ContentPanel.Size.Height - control.Size.Height) / 2);
        control.SizeChanged += (s, e) =>
            control.Location = new(control.Location.X, (ContentPanel.Size.Height - control.Size.Height) / 2);

        logger.LogInformation("[MainForm-Navigate] Navigated to control");
    }


    private void HomeButton_Click(object sender, EventArgs e) =>
        Navigate(new HomeControl());

    private void UserInfoButton_Click(object sender, EventArgs e) =>
        Navigate(new UserInfoControl());

    private void SettingsButton_Click(object sender, EventArgs e) =>
        Navigate(new SettingsControl());


    private void LoggerButton_Click(object sender, EventArgs e)
    {
        if (Program.LoggerForm is not null)
        {
            Program.LoggerForm.Activate();
            return;
        }

        TextBox textBox = new()
        {
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Both,
            Dock = DockStyle.Fill
        };

        Program.LoggerForm = new()
        {
            Text = "WinForms Sample (Logger) - Firebase Authentication",
            Width = 600,
            Height = 400,
        };
        Program.LoggerForm.Controls.Add(textBox);

        void handler(object? s, string e) =>
            textBox.Text += e;

        Program.Sink.OnNewLog += handler;
        Program.LoggerForm.Closed += (s, e) =>
        {
            Program.Sink.OnNewLog -= handler;
            Program.LoggerForm = null;
        };

        Program.LoggerForm.Show();

        logger.LogInformation("[MainForm-LoggerButton_Click] Created new LoggerForm and hooked handler");
    }

    private void GitHubButton_Click(object sender, EventArgs e) =>
        Process.Start(new ProcessStartInfo()
        {
            FileName = "https://github.com/IcySnex/Firebase.Authentication",
            UseShellExecute = true,
            CreateNoWindow = true
        });
}