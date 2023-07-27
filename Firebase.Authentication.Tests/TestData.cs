// This file is excluded from pushing to git.
// Use Git GUI to open repo, Press Repository (top left), Click Git Bash
// Commands:    LOCK FILE:      git update-index --skip-worktree Firebase.Authentication.Tests/TestData.cs
//              UNLOCK FILE:    git update-index --no-skip-worktree Firebase.Authentication.Tests/TestData.cs

using Firebase.Authentication.Internal.Json;
using Firebase.Authentication.Types;
using System.Net;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Tests;

internal class TestData
{
    /// <summary>
    /// Writes a serialized object as JSON in the default TestContext
    /// </summary>
    /// <param name="result">The object to write</param>
    public static void Write(
        object result)
    {
        string jsonResponse = JsonHelper.Serialize(result, new()
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        TestContext.WriteLine(jsonResponse);
    }


    /// <summary>
    /// The Firebase Web API key
    /// You can get find this here: https://console.firebase.google.com/u/0/project/<APPLICATION_NAME>/settings/general where <APPLICATION_NAME> represents your application name.
    /// </summary>
    public static readonly string ApiKey = "<FIREBASE WEB API KEY>";

    /// <summary>
    /// The time span in which a request times out
    /// </summary>
    public static readonly TimeSpan? Timeout = null;

    /// <summary>
    /// The proxy used for web requests
    /// </summary>
    public static readonly WebProxy? Proxy = null;


    /// <summary>
    /// The default continueUrl used for accounts.createAuthUrl authentication
    /// </summary>
    public static readonly string ContinueUrl = "<FIREBASE AUTH URL>";

    /// <summary>
    /// The default identifier used for accounts.createAuthUrl authentication
    /// </summary>
    public static readonly string Identifier = "<AUTH IDENTIFIER>";

    /// <summary>
    /// The default provider used for accounts.createAuthUrl authentication
    /// </summary>
    public static readonly Provider Provider = Provider.Google;


    /// <summary>
    /// The default CustomToken for authentication
    /// </summary>
    public static readonly string CustomToken =  "<CUSTOM TOKEN>";

    /// <summary>
    /// The default Id token for requests
    /// </summary>
    public static readonly string IdToken = "<ID TOKEN>";
    
    /// <summary>
    /// The default refresh token for requests
    /// </summary>
    public static readonly string RefreshToken = "<REFRESH TOKEN>";

    /// <summary>
    /// The default oob code for requests
    /// </summary>
    public static readonly string OobCode = "<OOB CODE>";


    /// <summary>
    /// The default reCaptcha token for send verification code
    /// </summary>
    public static readonly string ReCaptchaToken = "<RECAPTCHA TOKEN>";
    
    /// <summary>
    /// The default session info for sign in with phone number
    /// </summary>
    public static readonly string SessionInfo = "<SESSION INFO>";
    
    /// <summary>
    /// The default sms code for sign in with phone number
    /// </summary>
    public static readonly string SmsCode = "<SMS CODE>";


    /// <summary>
    /// The default request uri for sign in idp
    /// </summary>
    public static readonly string RequestUri = "<REQUEST URI>";

    /// <summary>
    /// The default post body for sign in idp
    /// </summary>
    public static readonly string PostBody = "id_token=<ID TOKEN>&providerId=<PROVIDER>";


    /// <summary>
    /// The default email address for authentication
    /// </summary>
    public static readonly string Email = "default@provider.com";

    /// <summary>
    /// The secondary email address for oob codes
    /// </summary>
    public static readonly string EmailSecondary = "default-ver2@provider.com";

    /// <summary>
    /// The default email address with a random number for authentication
    /// </summary>
    public static string RandomEmail => new Random().Next(0, 5000) + Email;

    /// <summary>
    /// The default password for authentication
    /// </summary>
    public static readonly string Password = "<PASSWORD>";

    /// <summary>
    /// The default phone number for authentication
    /// </summary>
    public static readonly string PhoneNumber = "<PHONE NUMBER>";

    /// <summary>
    /// The default displayname for sign ups
    /// </summary>
    public static readonly string DisplayName =  "<DISPLAY NAME>";

    /// <summary>
    /// The default photourl for sign ups
    /// </summary>
    public static readonly string PhotoUrl = "<PHOTO URL>";

    /// <summary>
    /// The language (Two Letter ISO code) in which all emails will be send to the user
    /// </summary>
    public static readonly string Locale = "en";


    /// <summary>
    /// The default return secure token value
    /// </summary>
    public static readonly bool ReturnSecureToken = true;

    /// <summary>
    /// The maxium tries to attempt to result in an TooManyAttempsException
    /// SET THIS TO THE MAX REGISTRATIONS PER HOUR FROM "FIREBASE AUTHENTICATION CONSOLE PANEL: SETTINGS: REGISTRATION QUOTA"
    /// </summary>
    public static readonly int MaxRetries = 10;
}