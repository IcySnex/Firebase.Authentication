using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class HomeView : Page
{
    readonly HomeViewModel viewModel = App.Provider.GetRequiredService<HomeViewModel>();

    public HomeView() =>
        InitializeComponent();
}