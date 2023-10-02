using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class LinkProviderView : Page
{
    readonly LinkProviderViewModel viewModel = App.Provider.GetRequiredService<LinkProviderViewModel>();

    public LinkProviderView() =>
        InitializeComponent();
}