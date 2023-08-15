using Firebase.Authentication.Models;
using System.Text.Json.Serialization;

namespace Firebase.Authentication.Responses.IdentityPlatform;

/// <summary>
/// Model to recieve a accounts.lookup response 
/// </summary>
public class LookupResponse
{
    /// <summary>
    /// Creates a new LookupResponse
    /// </summary>
    /// <param name="users">The information of specific user account(s) matching the parameters in the request</param>
    [JsonConstructor]
    public LookupResponse(
        UserInfo[] users)
    {
        Users = users;
    }

    /// <summary>
    /// The information of specific user account(s) matching the parameters in the request
    /// </summary>
    [JsonPropertyName("users")]
    public UserInfo[] Users { get; }
}