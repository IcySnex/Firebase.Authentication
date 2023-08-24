using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Types;
using Firebase.Authentication.Models;

namespace Firebase.Authentication.Tests.Client;

public class CreateProviderRedirect
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public void Setup()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        client = new AuthenticationClient(config);
    }


    [Test]
    public void Google_Success()
    {
        // Mock request/response
        ProviderRedirect response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.CreateProviderRedirectAsync(Provider.Google, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Github_Success()
    {
        // Mock request/response
        ProviderRedirect response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.CreateProviderRedirectAsync(Provider.Github, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }
    
    [Test]
    public void Apple_Success()
    {
        // Mock request/response
        ProviderRedirect response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.CreateProviderRedirectAsync(Provider.Apple, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Facebook_Success()
    {
        // Mock request/response
        ProviderRedirect response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.CreateProviderRedirectAsync(Provider.Faceook, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Twitter_Success()
    {
        // Mock request/response
        ProviderRedirect response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.CreateProviderRedirectAsync(Provider.Twitter, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Microsoft_Success()
    {
        // Mock request/response
        ProviderRedirect response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.CreateProviderRedirectAsync(Provider.Microsoft, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }

    [Test]
    public void Yahoo_Success()
    {
        // Mock request/response
        ProviderRedirect response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.CreateProviderRedirectAsync(Provider.Yahoo, TestData.ContinueUrl);
        });

        // Write result
        TestData.Write(response);
    }
}