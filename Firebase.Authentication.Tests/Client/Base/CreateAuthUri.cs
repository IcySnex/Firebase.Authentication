using Firebase.Authentication.Client.Base;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;

namespace Firebase.Authentication.Tests.Client.Base;

internal class CreateAuthUri
{
    IAuthenticationBase client;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);
        client = new AuthenticationBase(config);
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
            response = await client.CreateAuthUriAsync(request);
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
            response = await client.CreateAuthUriAsync(request);
        });

        // Write result
        TestData.Write(response);
    }
}