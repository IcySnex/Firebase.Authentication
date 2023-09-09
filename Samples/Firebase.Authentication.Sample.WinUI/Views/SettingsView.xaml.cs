using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class SettingsView : Page
{
    readonly SettingsViewModel viewModel = App.Provider.GetRequiredService<SettingsViewModel>();

    public SettingsView() =>
        InitializeComponent();
}