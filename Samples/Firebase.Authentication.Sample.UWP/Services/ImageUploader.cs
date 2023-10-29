using Firebase.Authentication.Sample.UWP.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.Storage;

namespace Firebase.Authentication.Sample.UWP.Services;

public class ImageUploader
{
    readonly ILogger<ImageUploader> logger;
    readonly JsonConverter converter;

    readonly HttpClient client = new();

    public ImageUploader(
        ILogger<ImageUploader> logger,
        IOptions<Models.Configuration> configuration,
        JsonConverter converter)
    {
        this.logger = logger;
        this.converter = converter;

        client.DefaultRequestHeaders.Authorization = new("Client-ID", configuration.Value.ImgurClientId);
    }


    public async Task<string> UploadAsync(
        StorageFile imageFile,
        string name)
    {
        using MultipartFormDataContent content = new();
        using Stream fileStream = await imageFile.OpenStreamForReadAsync();

        content.Add(new StreamContent(fileStream), "image", name);
        HttpResponseMessage response = await client.PostAsync("https://api.imgur.com/3/image", content);

        if (!response.IsSuccessStatusCode)
        {
            logger.LogError("[ImageUploader-UploadAsync] Image upload failed. Status code: " + response.StatusCode);
            throw new HttpRequestException("Failed uploading image", new(response.ReasonPhrase));
        }

        string responseContent = await response.Content.ReadAsStringAsync();
        ImageUploadResponse image = converter.ToObject<ImageUploadResponse>(responseContent) ?? throw new Exception("Failed converting to json");

        logger.LogInformation("[ImageUploader-UploadAsync] Image uploaded successfully.");
        return image.Data.Link;
    }
}