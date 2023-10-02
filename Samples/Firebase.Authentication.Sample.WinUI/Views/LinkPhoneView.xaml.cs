using Firebase.Authentication.Sample.WinUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Windows.System;

namespace Firebase.Authentication.Sample.WinUI.Views;

public sealed partial class LinkPhoneView : Page
{
    readonly LinkPhoneViewModel viewModel = App.Provider.GetRequiredService<LinkPhoneViewModel>();

    public LinkPhoneView() =>
        InitializeComponent();


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