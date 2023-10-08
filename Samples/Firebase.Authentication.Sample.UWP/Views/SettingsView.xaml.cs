﻿#nullable enable

using Firebase.Authentication.Sample.UWP.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Firebase.Authentication.Sample.UWP.Views;

public sealed partial class SettingsView : Page
{
    SettingsViewModel viewModel = App.Provider.GetRequiredService<SettingsViewModel>();

    public SettingsView()
    {
        InitializeComponent();
    }


    private void OnNumberBoxKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Enter || e.Key == VirtualKey.Back || e.Key == VirtualKey.Delete || e.Key == VirtualKey.Left || e.Key == VirtualKey.Right)
            return;

        e.Handled = (e.Key < VirtualKey.NumberPad0 || e.Key > VirtualKey.NumberPad9) && (e.Key < VirtualKey.NumberPad0 || e.Key > VirtualKey.NumberPad9);
    }
}