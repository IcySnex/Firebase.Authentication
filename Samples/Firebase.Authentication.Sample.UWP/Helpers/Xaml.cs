using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using System.Windows.Input;
using Windows.System;

namespace Firebase.Authentication.Sample.UWP.Helpers;

public static class Xaml
{
    public static readonly DependencyProperty EnterKeyCommandProperty = DependencyProperty.RegisterAttached(
        "EnterKeyCommand", typeof(ICommand), typeof(Xaml), new PropertyMetadata(null, OnEnterKeyCommandChanged));

    public static ICommand GetEnterKeyCommand(DependencyObject target) =>
        (ICommand)target.GetValue(EnterKeyCommandProperty);

    public static void SetEnterKeyCommand(DependencyObject target, ICommand value) =>
        target.SetValue(EnterKeyCommandProperty, value);


    static void OnEnterKeyCommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
    {
        ICommand command = (ICommand)e.NewValue;
        Control control = (Control)target;

        control.KeyDown += (s, args) =>
        {
            if (args.Key != VirtualKey.Enter)
                return;

            command.Execute(null);
        };
    }
}