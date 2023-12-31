﻿using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;
using Firebase.Authentication.Types;

namespace Firebase.Authentication.Tests.IdentityPlatform;

internal class SendOobCode
{
    IIdentityPlatformClient identityPlatform;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        identityPlatform = new IdentityPlatformClient(config);
    }


    [Test]
    public void VerifyEmail_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.VerifyEmail,
            idToken: TestData.IdToken);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void ResetPassword_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.ResetPassword,
            email: TestData.Email);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void VerifyAndChangeEmail_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.VerifyAndChangeEmail,
            newEmail: TestData.EmailSecondary,
            idToken: TestData.IdToken);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void SignInEmail_Success()
    {
        // Mock request/response
        SendOobCodeRequest request = new(
            requestType: OobType.SignInEmail,
            email: TestData.Email,
            continueUrl: TestData.ContinueUrl);
        SendOobCodeResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SendOobCodeAsync(request, TestData.Locale);
        });

        // Write result
        TestData.Write(response);
    }
}