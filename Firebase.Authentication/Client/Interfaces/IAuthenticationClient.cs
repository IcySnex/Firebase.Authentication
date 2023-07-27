using Firebase.Authentication.Models;
using System.ComponentModel;

namespace Firebase.Authentication.Client.Interfaces;

/// <summary>
/// Client for all high level Firebase Authentication actions
/// </summary>
public interface IAuthenticationClient : INotifyPropertyChanged
{
    /// <summary>
    /// The current client authentication
    /// </summary>
    public Models.Authentication? CurrentAuthentication { get; }

    /// <summary>
    /// The user who is currently logged into the client 
    /// </summary>
    public UserInfo? CurrentUser { get; }


    public void Hello();
}