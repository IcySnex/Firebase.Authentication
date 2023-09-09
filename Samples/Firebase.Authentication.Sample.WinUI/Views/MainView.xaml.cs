using Firebase.Authentication.Sample.WinUI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using Windows.System;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class MainView : Window
{
    public MainView()
    {
        SystemBackdrop = MicaController.IsSupported() ? new MicaBackdrop() : new DesktopAcrylicBackdrop();
        InitializeComponent();
    }


    private void OnLoggerClick(object _, RoutedEventArgs _1) =>
        App.Provider.GetRequiredService<WindowHelper>().CreateLoggerView();

    private async void OnGithubClick(object _, RoutedEventArgs _1) =>
        await Launcher.LaunchUriAsync(new("https://github.com/IcySnex/Firebase.Authentication"));
}