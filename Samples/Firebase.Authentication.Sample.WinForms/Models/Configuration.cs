namespace Firebase.Authentication.Sample.WinForms.Models;

public partial class Configuration
{
    /// <summary>
    /// The Firebase Web API key
    /// </summary>
    public string ApiKey = "";

    /// <summary>
    /// The time span in which a request times out
    /// </summary>
    public TimeSpan? HttpTimeout = null;

    /// <summary>
    /// The proxy used for web requests
    /// </summary>
    public string HttpProxy = "";


    /// <summary>
    /// The title of the provider flow form. (Use {provider} to use the provider name)
    /// </summary>
    public string Title = "WinForms Sample - Sign in with {provider}";

    /// <summary>
    /// The icon of the provider flow form (empty for provider default)
    /// </summary>
    public string Icon = "";

    /// <summary>
    /// The start position of the provider flow form
    /// </summary>
    public FormStartPosition StartPosition = FormStartPosition.CenterParent;

    /// <summary>
    /// The left position of the provider flow form
    /// </summary>
    public int Left = 0;

    /// <summary>
    /// The top position of the provider flow form
    /// </summary>
    public int Top = 0;

    /// <summary>
    /// Wether to block the UI thread when showing the provider flow form
    /// </summary>
    public bool ShowAsDialog = false;


    /// <summary>
    /// The url to which the provider will redirect the user back to (empty for provider default)
    /// </summary>
    public string FlowRedirectTo = "";

    /// <summary>
    /// The time span in which a user request times out
    /// </summary>
    public TimeSpan Timeout = TimeSpan.FromMinutes(1);


    /// <summary>
    /// The reCAPTCHA site key. (You can get your projects reCAPTCHA site key by using 'IAuthenticationClient.GetReCaptchaSiteKeyAsync')
    /// </summary>
    public string ReCaptchaSiteKey = "";

    /// <summary>
    /// The reCAPTCHA host name. (This has to be added to the authorized domains to work with ReCaptcha.Desktop)
    /// </summary>
    public string ReCaptchaHostName = "sample.firebase.authentication";


    /// <summary>
    /// The client ID for the Imgur api used to upload custom profile avatars
    /// </summary>
    public string ImgurClientId = "";
}