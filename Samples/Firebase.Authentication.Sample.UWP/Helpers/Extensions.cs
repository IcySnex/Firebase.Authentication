#nullable enable

using System;

namespace Firebase.Authentication.Sample.UWP.Helpers;

public static class Extensions
{
    public static Type? AsType(this string input,
        string assembly = "Firebase.Authentication.Sample.UWP") =>
        Type.GetType($"{assembly}.{input}, {assembly}");

}