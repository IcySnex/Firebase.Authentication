using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.IdentityPlatform;
using Firebase.Authentication.Responses.IdentityPlatform;

namespace Firebase.Authentication.Tests.IdentityPlatform;

internal class CreateAuthUri
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
    public void FetchProviders_Success()
    {
        // Mock request/response
        CreateAuthUriRequest request = new(
            continueUri: TestData.ContinueUrl,
            identifier: TestData.Identifier);
        CreateAuthUrlResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.CreateAuthUriAsync(request);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void CreateAuthUrl_Success()
    {
        // Mock request/response
        CreateAuthUriRequest request = new(
            continueUri: TestData.ContinueUrl,
            provider: TestData.Provider);
        CreateAuthUrlResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await identityPlatform.CreateAuthUriAsync(request);
        });

        // Write result
        TestData.Write(response);
    }
}