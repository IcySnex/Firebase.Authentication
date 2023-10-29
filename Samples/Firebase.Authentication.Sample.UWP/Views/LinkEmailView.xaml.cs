#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class LinkEmailView : Page
{
    readonly LinkEmailViewModel viewModel = App.Provider.GetRequiredService<LinkEmailViewModel>();

    public LinkEmailView() =>
        InitializeComponent();
}