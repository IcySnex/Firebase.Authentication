#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class LinkProviderView : Page
{
    readonly LinkProviderViewModel viewModel = App.Provider.GetRequiredService<LinkProviderViewModel>();

    public LinkProviderView() =>
        InitializeComponent();
}