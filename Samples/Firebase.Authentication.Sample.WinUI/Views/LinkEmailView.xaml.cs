using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class LinkEmailView : Page
{
    readonly LinkEmailViewModel viewModel = App.Provider.GetRequiredService<LinkEmailViewModel>();

    public LinkEmailView() =>
        InitializeComponent();
}