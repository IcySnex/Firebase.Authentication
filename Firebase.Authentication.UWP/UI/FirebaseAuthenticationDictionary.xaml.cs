using Windows.UI.Xaml;

namespace Firebase.Authentication.UWP.UI;

/// <summary>
/// Default resource dictionary for using the Firebase Authentication UI
/// </summary>
public partial class FirebaseAuthenticationDictionary : ResourceDictionary
{
    /// <summary>
    /// Creates a new FirebaseAuthenticationDictionary
    /// </summary>
    public FirebaseAuthenticationDictionary()
    {
        InitializeComponent();
        
    }


    /// <summary>
    /// Loads all provider icons for the FirebaseAuthenticationButtons.
    /// <br/>
    /// I have no damn idea why I cant load SvgImageSources in the constructor of the FirebaseAuthenticationDictionary like in WinUi3 but youll have to live with it ig.
    /// <see href="https://stackoverflow.com/questions/77293523/svgimagesource-not-loading-in-custom-element-using-resourcedictionary"/>
    /// </summary>
    /// <param name="dctionary"></param>
    public static void LoadIcons(
        ResourceDictionary dctionary)
    {
        ((Style)dctionary["DefaultFirebaseAuthenticationButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Firebase, 19, 19)));
        ((Style)dctionary["EmailAndPasswordButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.EmailAndPassword, 19, 19)));
        ((Style)dctionary["PhoneNumberButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.PhoneNumber, 19, 19)));
        ((Style)dctionary["FacebookButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Facebook, 19, 19)));
        ((Style)dctionary["GoogleButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Google, 19, 19)));
        ((Style)dctionary["AppleButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Apple, 19, 19)));
        ((Style)dctionary["GithubButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Github, 19, 19)));
        ((Style)dctionary["TwitterButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Twitter, 19, 19)));
        ((Style)dctionary["MicrosoftButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Microsoft, 19, 19)));
        ((Style)dctionary["YahooButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Yahoo, 19, 19)));
        ((Style)dctionary["AnonymouslyButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Anonymously, 19, 19)));
    }
}