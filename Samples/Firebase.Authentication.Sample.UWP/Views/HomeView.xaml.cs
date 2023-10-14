#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class HomeView : Page
{
    HomeViewModel viewModel = App.Provider.GetRequiredService<HomeViewModel>();

    public HomeView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {

    }
}