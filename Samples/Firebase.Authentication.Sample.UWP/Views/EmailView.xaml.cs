#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class EmailView : Page
{
    EmailViewModel viewModel = App.Provider.GetRequiredService<EmailViewModel>();

    public EmailView()
    {
        InitializeComponent();
    }
}