using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class UserView : Page
{
    readonly UserViewModel viewModel = App.Provider.GetRequiredService<UserViewModel>();

    public UserView()
    {
        InitializeComponent();

        UISettings ui = new();
        SetHeaderGraident(ui.GetColorValue(UIColorType.Accent));

        ui.ColorValuesChanged += (s, e) =>
            DispatcherQueue.TryEnqueue(() => SetHeaderGraident(s.GetColorValue(UIColorType.Accent)));
    }


    void SetHeaderGraident(
        Color color)
    {
        HeaderGradient.GradientStops.Clear();

        HeaderGradient.GradientStops.Add(new() { Offset = 0, Color = color });
        HeaderGradient.GradientStops.Add(new() { Offset = 1, Color = Color.FromArgb(0, color.R, color.G, color.B) });
    }
}