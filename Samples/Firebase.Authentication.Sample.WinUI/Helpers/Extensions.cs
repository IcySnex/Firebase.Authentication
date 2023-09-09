namespace Firebase.Authentication.Sample.WinUI.Helpers;

public static class Extensions
{
    public static Type? AsType(this string input,
        string assembly = "Firebase.Authentication.Sample.WinUI") =>
        Type.GetType($"{assembly}.{input}, {assembly}");
}