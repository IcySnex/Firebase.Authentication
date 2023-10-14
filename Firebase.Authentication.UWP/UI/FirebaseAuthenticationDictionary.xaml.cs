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

        ((Style)this["DefaultFirebaseAuthenticationButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Firebase, 19, 19)));
        ((Style)this["EmailAndPasswordButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.EmailAndPassword, 19, 19)));
        ((Style)this["PhoneNumberButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.PhoneNumber, 19, 19)));
        ((Style)this["FacebookButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Facebook, 19, 19)));
        ((Style)this["GoogleButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Google, 19, 19)));
        ((Style)this["AppleButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Apple, 19, 19)));
        ((Style)this["GithubButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Github, 19, 19)));
        ((Style)this["TwitterButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Twitter, 19, 19)));
        ((Style)this["MicrosoftButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Microsoft, 19, 19)));
        ((Style)this["YahooButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Yahoo, 19, 19)));
        ((Style)this["AnonymouslyButtonStyle"]).Setters.Add(new Setter(FirebaseAuthenticationButton.IconProperty, Icons.ToImageSource(Icons.Anonymously, 19, 19)));
    }
}