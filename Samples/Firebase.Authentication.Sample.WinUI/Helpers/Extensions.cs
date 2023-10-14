using Firebase.Authentication.Types;
using Microsoft.UI.Xaml;

namespace Firebase.Authentication.Sample.WinUI.Helpers;

public static class Extensions
{
    public static Type? AsType(this string input,
        string assembly = "Firebase.Authentication.Sample.WinUI") =>
        Type.GetType($"{assembly}.{input}, {assembly}");


    public static Visibility ContainsProviderToVisibility(
        Provider[]? providers,
        Provider provider) =>
        providers is null ? Visibility.Collapsed : providers.Contains(provider) ? Visibility.Visible : Visibility.Collapsed;

    public static Visibility ExcludesProviderToVisibility(
        Provider[]? providers,
        Provider provider) =>
        providers is null ? Visibility.Visible : providers.Contains(provider) ? Visibility.Collapsed : Visibility.Visible;

}