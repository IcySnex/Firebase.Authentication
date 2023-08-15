using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;

namespace Firebase.Authentication.Tests.IdentityPlatform;

internal class SignIn
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
    public void SignInWithCustomToken_Success()
    {
        // Mock request/response
        SignInWithCustomTokenRequest request = new(
            token: TestData.CustomToken);
        SignInWithCustomTokenResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SignInWithCustomTokenAsync(request);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void SignInWithEmailLink_Success()
    {
        // Mock request/response
        SignInWithEmailLinkRequest request = new(
            oobCode: TestData.OobCode,
            email: TestData.Email);
        SignInWithEmailLinkResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SignInWithEmailLinkAsync(request);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void SignInWithIdp_Success()
    {
        // Mock request/response
        SignInWithIdpRequest request = new(
            requestUri: TestData.RequestUri,
            sessionId: TestData.SessionId);
        SignInWithIdpResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SignInWithIdpAsync(request);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void SignInWithPassword_Success()
    {
        // Mock request/response
        SignInWithPasswordRequest request = new(
            email: TestData.Email,
            password: TestData.Password);
        SignInWithPasswordResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SignInWithPasswordAsync(request);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void SignInWithPhoneNumber_Success()
    {
        // Mock request/response
        SignInWithPhoneNumberRequest request = new(
            sessionInfo: TestData.SessionInfo,
            code: TestData.SmsCode);
        SignInWithPhoneNumberResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SignInWithPhoneNumberAsync(request);
        });

        // Write result
        TestData.Write(response);
    }
}