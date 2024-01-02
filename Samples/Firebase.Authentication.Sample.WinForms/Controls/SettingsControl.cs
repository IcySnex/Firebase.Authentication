namespace Firebase.Authentication.Sample.WinForms.Controls;

public partial class SettingsControl : UserControl
{
    public SettingsControl()
    {
        InitializeComponent();

        ApiKeyContent.DataBindings.Add(new("Text", Program.Configuration, "ApiKey"));
        HttpTimeoutContent.DataBindings.Add(new("Text", this, "HttpTimeout"));
        HttpProxyContent.DataBindings.Add(new("Text", Program.Configuration, "HttpProxy"));
        TitleContent.DataBindings.Add(new("Text", Program.Configuration, "Title"));
        IconContent.DataBindings.Add(new("Text", Program.Configuration, "Icon"));
        StartPositionContent.DataSource = Enum.GetValues(typeof(FormStartPosition));
        StartPositionContent.DataBindings.Add(new("SelectedItem", Program.Configuration, "StartPosition"));
        LeftContent.DataBindings.Add(new("Value", Program.Configuration, "Left"));
        TopContent.DataBindings.Add(new("Value", Program.Configuration, "Top"));
        ShowAsDialogContent.DataBindings.Add(new("Checked", Program.Configuration, "ShowAsDialog"));
        FlowRedirectToContent.DataBindings.Add(new("Text", Program.Configuration, "FlowRedirectTo"));
        TimeoutContent.DataBindings.Add(new("Text", this, "Timeout"));
        ReCaptchaSiteKeyContent.DataBindings.Add(new("Text", Program.Configuration, "ReCaptchaSiteKey"));
        ReCaptchaHostNameContent.DataBindings.Add(new("Text", Program.Configuration, "ReCaptchaHostName"));
        ImgurClientIdContent.DataBindings.Add(new("Text", Program.Configuration, "ImgurClientId"));
    }

    public string? HttpTimeout
    {
        get => Program.Configuration.HttpTimeout.ToString();
        set => Program.Configuration.HttpTimeout = value is null ? null : TimeSpan.Parse(value);
    }

    public string? Timeout
    {
        get => Program.Configuration.Timeout.ToString();
        set => Program.Configuration.Timeout = value is null ? null : TimeSpan.Parse(value);
    }


    private void RestartButton_Click(object sender, EventArgs e) =>
        Application.Restart();
}