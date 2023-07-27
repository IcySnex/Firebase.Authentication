using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;

namespace Firebase.Authentication.Tests.Client.Base;

internal class Lookup
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
    public void Success()
    {
        // Mock request/response
        LookupRequest request = new(
            idToken: TestData.IdToken);
        LookupResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.LookupAsync(request);
        });

        // Write result
        TestData.Write(response);
    }
}