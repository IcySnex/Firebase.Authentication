﻿namespace Firebase.Authentication.Exceptions;

public class InvalidApiKeyException : IdentityPlatformException
{
    /// <summary>
    /// API key not valid. Please pass a valid API key. (invalid API key provided)
    /// </summary>
    public InvalidApiKeyException() : base("INVALID_API_KEY", "API key not valid. Please pass a valid API key. (invalid API key provided)") { }
}