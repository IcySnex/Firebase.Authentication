﻿using System.Text.Json.Serialization;

namespace Firebase.Authentication.Sample.WinForms.Models;

public class ImageUploadResponse
{
    [JsonConstructor]
    public ImageUploadResponse(
        ImageUploadResponseData data)
    {
        Data = data;
    }

    [JsonPropertyName("data")]
    public ImageUploadResponseData Data { get; }
}

public class ImageUploadResponseData
{
    [JsonConstructor]
    public ImageUploadResponseData(
        string link,
        string deletehash)
    {
        Link = link;
        Deletehash = deletehash;
    }

    [JsonPropertyName("link")]
    public string Link { get; }

    [JsonPropertyName("deletehash")]
    public string Deletehash { get; }
}