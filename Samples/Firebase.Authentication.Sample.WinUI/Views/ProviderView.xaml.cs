using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class ProviderView : Page
{
    readonly ProviderViewModel viewModel = App.Provider.GetRequiredService<ProviderViewModel>();

    public ProviderView()
    {
        InitializeComponent();
    }
}