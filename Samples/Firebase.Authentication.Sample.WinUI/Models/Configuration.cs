using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Authentication.WinUI.Configuration;

namespace Firebase.Authentication.Sample.WinUI.Models;

public partial class Configuration : ObservableObject
{
    /// <summary>
    /// The Firebase Web API key
    /// </summary>
    [ObservableProperty]
    string apiKey = "";

    /// <summary>
    /// The time span in which a request times out
    /// </summary>
    [ObservableProperty]
    TimeSpan? httpTimeout = null;

    /// <summary>
    /// The proxy used for web requests
    /// </summary>
    [ObservableProperty]
    string httpProxy = "";


    /// <summary>
    /// The title of the provider flow window. (Use {provider} to use the provider name)
    /// </summary>
    [ObservableProperty]
    string title = "WinUI Sample - Sign in with {provider}";

    /// <summary>
    /// The icon of the provider flow window (empty for provider default)
    /// </summary>
    [ObservableProperty]
    string icon = "";

    /// <summary>
    /// The startup location of the provider flow window
    /// </summary>
    [ObservableProperty]
    WindowStartupLocation startupLocation = WindowStartupLocation.CenterOwner;

    /// <summary>
    /// The left position of the provider flow window
    /// </summary>
    [ObservableProperty]
    int left = 0;

    /// <summary>
    /// The top position of the provider flow window
    /// </summary>
    [ObservableProperty]
    int top = 0;

    /// <summary>
    /// Wether to block the UI thread when showing the provider flow window
    /// </summary>
    [ObservableProperty]
    bool showAsDialog = false;


    /// <summary>
    /// The url to which the provider will redirect the user back to (empty for provider default)
    /// </summary>
    [ObservableProperty]
    string flowRedirectTo = "";

    /// <summary>
    /// The time span in which a user request times out
    /// </summary>
    [ObservableProperty]
    TimeSpan timeout = TimeSpan.FromMinutes(1);


    /// <summary>
    /// The reCAPTCHA site key. (You can get your projects reCAPTCHA site key by using 'IAuthenticationClient.GetReCaptchaSiteKeyAsync')
    /// </summary>
    [ObservableProperty]
    string reCaptchaSiteKey = "";

    /// <summary>
    /// The reCAPTCHA host name. (This has to be added to the authorized domains to work with ReCaptcha.Desktop)
    /// </summary>
    [ObservableProperty]
    string reCaptchaHostName = "sample.firebase.authenticaion";


    /// <summary>
    /// The client ID for the Imgur api used to upload custom profile avatars
    /// </summary>
    [ObservableProperty]
    string imgurClientId = "";
}