using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Internal.Json;

internal class MsJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        DateTimeOffset.FromUnixTimeMilliseconds(reader.GetInt64()).ToLocalTime().DateTime;

    public override void Write(
        Utf8JsonWriter writer,
        DateTime dateTime,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(new DateTimeOffset(dateTime, new(0)).ToUnixTimeMilliseconds().ToString());
}


internal class MsStringJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        DateTimeOffset.FromUnixTimeMilliseconds(reader.GetString() is string s ? long.Parse(s) : 0).ToLocalTime().DateTime;

    public override void Write(
        Utf8JsonWriter writer,
        DateTime dateTime,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(new DateTimeOffset(dateTime, new(0)).ToUnixTimeMilliseconds().ToString());
}


internal class SStringJsonConverter : JsonConverter<DateTime>
{
    public override DateTime Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        DateTimeOffset.FromUnixTimeSeconds(reader.GetString() is string s ? long.Parse(s) : 0).ToLocalTime().DateTime;

    public override void Write(
        Utf8JsonWriter writer,
        DateTime dateTime,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(new DateTimeOffset(dateTime, new(0)).ToUnixTimeSeconds().ToString());
}


internal class SecondsJsonConverter : JsonConverter<TimeSpan>
{
    public override TimeSpan Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        double seconds = reader.TokenType switch
        {
            JsonTokenType.String => double.Parse(reader.GetString()),
            JsonTokenType.Number => reader.GetDouble(),
            _ => 0
        };

        return TimeSpan.FromSeconds(seconds);
    }

    public override void Write(
        Utf8JsonWriter writer,
        TimeSpan timeSpan,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(timeSpan.TotalSeconds > 0 ? timeSpan.TotalSeconds.ToString() : null);
}