using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class EmailView : Page
{
    readonly EmailViewModel viewModel = App.Provider.GetRequiredService<EmailViewModel>();

    public EmailView()
    {
        InitializeComponent();
    }
}