using Microsoft.UI.Xaml;

namespace Firebase.Authentication.Sample.WinUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }


    Window m_window = default!;

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        m_window = new MainWindow();
        m_window.Activate();
    }
}