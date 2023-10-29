#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using System;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class UserView : Page
{
    readonly UserViewModel viewModel = App.Provider.GetRequiredService<UserViewModel>();

    public UserView()
    {
        InitializeComponent();

        UISettings ui = new();
        SetHeaderGraident(ui.GetColorValue(UIColorType.Accent));

        ui.ColorValuesChanged += async (s, e) =>
            await Dispatcher.TryRunAsync(CoreDispatcherPriority.Normal, () => SetHeaderGraident(s.GetColorValue(UIColorType.Accent)));
    }


    void SetHeaderGraident(
        Color color)
    {
        HeaderGradient.GradientStops.Clear();

        HeaderGradient.GradientStops.Add(new() { Offset = 0, Color = color });
        HeaderGradient.GradientStops.Add(new() { Offset = 1, Color = Color.FromArgb(0, color.R, color.G, color.B) });
    }
}