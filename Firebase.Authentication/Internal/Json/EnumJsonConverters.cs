using Firebase.Authentication.Types;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Internal.Json;

internal class ProviderJsonConverter : JsonConverter<Provider>
{
    public override Provider Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        reader.GetString() is string s ? EnumHelper.ToEnum<Provider>(s) : default!;


    public override void Write(
        Utf8JsonWriter writer,
        Provider provider,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(EnumHelper.ToString(provider));
}


internal class GrantTypeJsonConverter : JsonConverter<GrantType>
{
    public override GrantType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        reader.GetString() is string s ? EnumHelper.ToEnum<GrantType>(s) : GrantType.RefreshToken;


    public override void Write(
        Utf8JsonWriter writer,
        GrantType grandType,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(EnumHelper.ToString(grandType));
}


internal class OobTypeJsonConverter : JsonConverter<OobType>
{
    public override OobType Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options) =>
        reader.GetString() is string s ? EnumHelper.ToEnum<OobType>(s) : OobType.ResetPassword;


    public override void Write(
        Utf8JsonWriter writer,
        OobType oobType,
        JsonSerializerOptions options) =>
        writer.WriteStringValue(EnumHelper.ToString(oobType));
}