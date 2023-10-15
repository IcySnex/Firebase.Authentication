#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class PhoneView : Page
{
    PhoneViewModel viewModel = App.Provider.GetRequiredService<PhoneViewModel>();

    public PhoneView()
    {
        InitializeComponent();
    }


    private void OnPhoneNumberTextBoxKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Back || e.Key == VirtualKey.Delete || e.Key == VirtualKey.Left || e.Key == VirtualKey.Right)
            return;

        e.Handled = !(e.Key == VirtualKey.Add || (e.Key >= VirtualKey.Number0 && e.Key <= VirtualKey.Number9) || (e.Key >= VirtualKey.NumberPad0 && e.Key <= VirtualKey.NumberPad9));
    }

    private void OnCodeKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Back || e.Key == VirtualKey.Delete || e.Key == VirtualKey.Left || e.Key == VirtualKey.Right)
            return;

        e.Handled = (e.Key < VirtualKey.Number0 || e.Key > VirtualKey.Number9) && (e.Key < VirtualKey.NumberPad0 || e.Key > VirtualKey.NumberPad9);
    }
}