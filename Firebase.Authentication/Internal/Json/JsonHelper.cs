using Firebase.Authentication.Exceptions;
using System.Text.Json;

namespace Firebase.Authentication.Internal.Json;

/// <summary>
/// Helper collection for all JSON related actions
/// </summary>
internal class JsonHelper
{
    /// <summary>
    /// Converts a json stirng into an object
    /// </summary>
    /// <typeparam name="T">The excpected return type</typeparam>
    /// <param name="input">The json string to convert</param>
    /// <param name="options">Options to control the conversion behavior</param>
    /// <returns>A converted object representing the json string</returns>
    /// <exception cref="ArgumentNullException">Occurs when json null is</exception>
    /// <exception cref="JsonException">Occurs when the JSON is invalid. -or- TValue is not compatible with the JSON. -or- There is remaining data in the string beyond a single JSON value.</exception>
    /// <exception cref="NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    /// <exception cref="JsonObjectIsNullException">Occurs when deserialized object does not represent the Type T (is null)</exception>
    public static T Deserialize<T>(
        string input,
        JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Deserialize<T>(input, options) is T result ?
            result : throw new JsonObjectIsNullException();
    }

    /// <summary>
    /// Converts an object into a json string
    /// </summary>
    /// <param name="input">The json string to convert</param>
    /// <param name="options">Options to control the conversion behavior</param>
    /// <returns>A json string representing the object</returns>
    /// <exception cref="NotSupportedException">Occurs when there is no compatible System.Text.Json.Serialization.JsonConverter for TValue</exception>
    public static string Serialize(
        object input,
        JsonSerializerOptions? options = null)
    {
        return JsonSerializer.Serialize(input, options);
    }
}