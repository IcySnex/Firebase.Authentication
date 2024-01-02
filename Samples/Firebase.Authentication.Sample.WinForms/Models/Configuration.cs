namespace Firebase.Authentication.Sample.WinForms.Models;

public partial class Configuration
{
    /// <summary>
    /// The Firebase Web API key
    /// </summary>
    public string ApiKey { get; set; } = "";

    /// <summary>
    /// The time span in which a request times out
    /// </summary>
    public TimeSpan? HttpTimeout { get; set; } = null;

    /// <summary>
    /// The proxy used for web requests
    /// </summary>
    public string HttpProxy { get; set; } = "";


    /// <summary>
    /// The title of the provider flow form. (Use {provider} to use the provider name)
    /// </summary>
    public string Title { get; set; } = "WinForms Sample - Sign in with {provider}";

    /// <summary>
    /// The icon of the provider flow form (empty for provider default)
    /// </summary>
    public string Icon { get; set; } = "";

    /// <summary>
    /// The start position of the provider flow form
    /// </summary>
    public FormStartPosition StartPosition { get; set; } = FormStartPosition.CenterParent;

    /// <summary>
    /// The left position of the provider flow form
    /// </summary>
    public int Left { get; set; } = 0;

    /// <summary>
    /// The top position of the provider flow form
    /// </summary>
    public int Top { get; set; } = 0;

    /// <summary>
    /// Wether to block the UI thread when showing the provider flow form
    /// </summary>
    public bool ShowAsDialog { get; set; } = false;


    /// <summary>
    /// The url to which the provider will redirect the user back to (empty for provider default)
    /// </summary>
    public string FlowRedirectTo { get; set; } = "";

    /// <summary>
    /// The time span in which a user request times out
    /// </summary>
    public TimeSpan? Timeout { get; set; } = TimeSpan.FromMinutes(1);


    /// <summary>
    /// The reCAPTCHA site key. (You can get your projects reCAPTCHA site key by using 'IAuthenticationClient.GetReCaptchaSiteKeyAsync')
    /// </summary>
    public string ReCaptchaSiteKey { get; set; } = "";

    /// <summary>
    /// The reCAPTCHA host name. (This has to be added to the authorized domains to work with ReCaptcha.Desktop)
    /// </summary>
    public string ReCaptchaHostName { get; set; } = "sample.firebase.authentication";


    /// <summary>
    /// The client ID for the Imgur api used to upload custom profile avatars
    /// </summary>
    public string ImgurClientId { get; set; } = "";
}