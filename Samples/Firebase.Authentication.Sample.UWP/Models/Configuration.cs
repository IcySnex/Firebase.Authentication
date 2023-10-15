using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Authentication.UWP.Configuration;
using System;

namespace Firebase.Authentication.Sample.UWP.Models;

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
    /// The title of the provider flow popup. (Use {provider} to use the provider name)
    /// </summary>
    [ObservableProperty]
    string title = "UWP Sample - Sign in with {provider}";

    /// <summary>
    /// The icon of the provider flow popup (empty for provider default)
    /// </summary>
    [ObservableProperty]
    string icon = "";

    /// <summary>
    /// Wether the provider flow popup has a TitleBar
    /// </summary>
    [ObservableProperty]
    bool hasTitleBar = true;

    /// <summary>
    /// Wether the provider flow popup is draggable within the main window
    /// (Only used when HasTitleBar is true)
    /// </summary>
    [ObservableProperty]
    bool isDragable = false;

    /// <summary>
    /// Wether the provider flow popup dims the main windows background
    /// </summary>
    [ObservableProperty]
    bool isDimmed = true;

    /// <summary>
    /// Wether the provider flow popup has rounded corners
    /// (If null the value is true on Windows 11 and false on Windows 10)
    /// </summary>
    [ObservableProperty]
    bool? hasRoundedCorners = null;

    /// <summary>
    /// The startup location of the provider flow popup
    /// </summary>
    [ObservableProperty]
    PopupStartupLocation startupLocation = PopupStartupLocation.CenterPrimary;

    /// <summary>
    /// The left position of the provider flow popup
    /// </summary>
    [ObservableProperty]
    int left = 0;

    /// <summary>
    /// The top position of the provider flow popup
    /// </summary>
    [ObservableProperty]
    int top = 0;


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