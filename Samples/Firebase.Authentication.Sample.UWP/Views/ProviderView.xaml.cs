#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class ProviderView : Page
{
    ProviderViewModel viewModel = App.Provider.GetRequiredService<ProviderViewModel>();

    public ProviderView()
    {
        InitializeComponent();
    }
}