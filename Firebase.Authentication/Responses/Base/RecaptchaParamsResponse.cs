using Firebase.Authentication.Internal.Json;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.Base;

/// <summary>
/// Model to recieve a getRecaptchaParams response 
/// </summary>
public class RecaptchaParamsResponse
{
    /// <summary>
    /// Creates a new RecaptchaParamsResponse
    /// </summary>
    /// <param name="recaptchaSiteKey">The reCAPTCHA v2 site key used to invoke the reCAPTCHA service</param>
    /// <param name="producerProjectNumber">The producer project number used to generate PIA tokens</param>
    [JsonConstructor]
    public RecaptchaParamsResponse(
        string recaptchaSiteKey,
        string producerProjectNumber)
    {
        RecaptchaSiteKey = recaptchaSiteKey;
        ProducerProjectNumber = producerProjectNumber;
    }

    /// <summary>
    /// The reCAPTCHA v2 site key used to invoke the reCAPTCHA service
    /// </summary>
    [JsonPropertyName("recaptchaSiteKey")]
    public string RecaptchaSiteKey { get; }

    /// <summary>
    /// The producer project number used to generate PIA tokens
    /// </summary>
    [JsonPropertyName("producerProjectNumber")]
    public string ProducerProjectNumber { get; }
}