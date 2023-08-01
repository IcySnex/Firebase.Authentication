using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Responses.Base;

namespace Firebase.Authentication.Tests.Client.Base;

internal class GetRecaptchaParams
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
        RecaptchaParamsResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.GetRecaptchaParamsAsync();
        });

        // Write result
        TestData.Write(response);
    }
}