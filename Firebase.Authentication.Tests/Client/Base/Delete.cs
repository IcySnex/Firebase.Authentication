using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.Base;

namespace Firebase.Authentication.Tests.Client.Base;

internal class Delete
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
        DeleteRequest request = new(
            idToken: TestData.IdToken);

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.DeleteAsync(request);
        });
    }
}