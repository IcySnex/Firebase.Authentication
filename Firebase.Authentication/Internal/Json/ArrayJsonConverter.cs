using Firebase.Authentication.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Internal.Json;

internal class ArrayStringConverter : JsonConverter<string[]>
{
    public override string[] Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        List<string> list = new();

        reader.Read();

        while (reader.TokenType != JsonTokenType.EndArray)
        {
            list.Add(JsonSerializer.Deserialize<string>(ref reader, options)!);
            reader.Read();
        }

        return list.ToArray();
    }

    public override void Write(
        Utf8JsonWriter writer,
        string[] array,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(string.Join(",", array));
    }
}


internal class ProviderArrayJsonConverter : JsonConverter<Provider[]>
{
    public override Provider[] Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        List<Provider> list = new();

        reader.Read();

        while (reader.TokenType != JsonTokenType.EndArray)
        {
            list.Add(EnumHelper.ToEnum<Provider>(JsonSerializer.Deserialize<string>(ref reader, options)!));
            reader.Read();
        }

        return list.ToArray();
    }

    public override void Write(
        Utf8JsonWriter writer,
        Provider[] providerArray,
        JsonSerializerOptions options)
    {
        foreach (Provider provider in providerArray)
            writer.WriteStringValue(EnumHelper.ToString(provider));
    }
}


internal class UserAttributeNameArrayJsonConverter : JsonConverter<UserAttributeName[]>
{
    public override UserAttributeName[] Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartArray)
            throw new JsonException();

        List<UserAttributeName> list = new();

        reader.Read();

        while (reader.TokenType != JsonTokenType.EndArray)
        {
            list.Add(EnumHelper.ToEnum<UserAttributeName>(JsonSerializer.Deserialize<string>(ref reader, options)!));
            reader.Read();
        }

        return list.ToArray();
    }

    public override void Write(
        Utf8JsonWriter writer,
        UserAttributeName[] userAttributeNameArray,
        JsonSerializerOptions options)
    {
        foreach (UserAttributeName provider in userAttributeNameArray)
            writer.WriteStringValue(EnumHelper.ToString(provider));
    }
}
