using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;

namespace Firebase.Authentication.Tests.IdentityPlatform;

internal class SignUp
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
    public void Anonymsously_Success()
    {
        // Mock request/response
        SignUpRequest request = new();
        SignUpResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SignUpAsync(request);
        });

        // Write result
        TestData.Write(response);
    }


    [Test]
    public void EmailPassword_Success()
    {
        // Mock request/response
        SignUpRequest request = new(
            email: TestData.Email,
            password: TestData.Password,
            displayName: TestData.DisplayName,
            photoUrl: TestData.PhotoUrl);
        SignUpResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.SignUpAsync(request);
        });

        // Write result
        TestData.Write(response);
    }
}