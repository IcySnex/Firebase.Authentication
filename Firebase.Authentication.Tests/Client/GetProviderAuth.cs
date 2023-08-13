using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Types;
using Firebase.Authentication.Models;

namespace Firebase.Authentication.Tests.Client;

public class GetProviderAuth
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        client = new AuthenticaionClient(config);
    }


    [Test]
    public void Google_Success()
    {
        // Mock request/response
        ProviderAuth response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.GetProviderAuthAsync(Provider.Google, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Github_Success()
    {
        // Mock request/response
        ProviderAuth response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.GetProviderAuthAsync(Provider.Github, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Microsoft_Success()
    {
        // Mock request/response
        ProviderAuth response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.GetProviderAuthAsync(Provider.Microsoft, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Twitter_Success()
    {
        // Mock request/response
        ProviderAuth response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.GetProviderAuthAsync(Provider.Twitter, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }
    [Test]
    public void Facebook_Success()
    {
        // Mock request/response
        ProviderAuth response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.GetProviderAuthAsync(Provider.Faceook, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }
}