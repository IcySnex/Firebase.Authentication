using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;

namespace Firebase.Authentication.Tests.Client;

internal class Client
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
    public void Success()
    {
        client.PropertyChanged += (s, e) =>
        {
            TestContext.WriteLine(e.PropertyName);
        };

        client.Hello();
    }
}