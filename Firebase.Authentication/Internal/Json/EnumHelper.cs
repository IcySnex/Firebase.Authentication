using System.Reflection;
using System.Runtime.Serialization;

namespace Firebase.Authentication.Internal.Json;

/// <summary>
/// Helper collection for all enum related actions
/// </summary>
internal class EnumHelper
{
    /// <summary>
    /// Gets an enum by the EnumMember attribute value name
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <param name="input">The name of the searching enum</param>
    /// <returns>The enum</returns>
    public static T? ToEnum<T>(
        string input)
    {
        var enumType = typeof(T);
        foreach (string name in Enum.GetNames(enumType))
        {
            FieldInfo? field = enumType.GetField(name);
            if (field is null)
                return default;

            EnumMemberAttribute enumMemberAttribute = ((EnumMemberAttribute[])field.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
            if (enumMemberAttribute.Value == input)
                return (T)Enum.Parse(enumType, name);
        }

        return default;
    }

    /// <summary>
    /// Gets the EnumMember attribute value name
    /// </summary>
    /// <typeparam name="T">The type of the enum</typeparam>
    /// <param name="type">The type of the enum</param>
    /// <param name="defaultValue">The default value if no enum is found</param>
    /// <returns>The string</returns>
    public static string? ToString<T>(
        T type)
    {
        if (type is null)
            return null;

        Type enumType = typeof(T);

        string? name = Enum.GetName(enumType, type);
        if (name is null)
            return null;

        FieldInfo? field = enumType.GetField(name);
        if (field is null)
            return null;

        EnumMemberAttribute enumMemberAttribute = ((EnumMemberAttribute[])field.GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
        if (enumMemberAttribute.Value is null)
            return null;

        return enumMemberAttribute.Value;
    }
}