using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Models;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Firebase.Authentication.Client;

/// <summary>
/// Client for all high level Firebase Authentication actions implementing INotifyPropertyChanged
/// </summary>
public class AuthenticaionClient : IAuthenticationClient, INotifyPropertyChanged
{
    readonly IAuthenticationBase baseClient;

    readonly ILogger<IAuthenticationClient>? logger;

    /// <summary>
    /// Creates a new AuthenticaionClient
    /// </summary>
    /// <param name="config">The configuration the AuthenticationClient should be created</param>
    public AuthenticaionClient(
        AuthenticationConfig config)
    {
        baseClient = new AuthenticationBase(config);
    }

    /// <summary>
    /// Creates a new AuthenticaionClient with extendended logging functions
    /// </summary>
    /// <param name="config">The configuration the AuthenticationClient should be created</param>
    /// <param name="logger">The logger which will be used to log</param>
    public AuthenticaionClient(
        AuthenticationConfig config,
        ILogger<IAuthenticationClient>? logger)
    {
        baseClient = new AuthenticationBase(config, logger);
        this.logger = logger;
    }


    /// <summary>
    /// Occurrs when a property value changes
    /// </summary>
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(
        [CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual bool SetProperty<T>(ref T field, T newValue, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, newValue))
            return false;

        field = newValue;
        OnPropertyChanged(propertyName);
        return true;
    }


    /// <summary>
    /// The current client authentication
    /// </summary>
    public Models.Authentication? CurrentAuthentication
    {
        get => currentAuthentication;
        private set => SetProperty(ref currentAuthentication, value);
    }

    Models.Authentication? currentAuthentication;

    /// <summary>
    /// The user who is currently logged into the client 
    /// </summary>
    public UserInfo? CurrentUser
    {
        get => currentUser;
        private set => SetProperty(ref currentUser, value);
    }

    UserInfo? currentUser;


    public void Hello()
    {
    }
}