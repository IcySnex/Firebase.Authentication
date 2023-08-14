using Firebase.Authentication.Client;
using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests.Base;
using Firebase.Authentication.Responses.Base;

namespace Firebase.Authentication.Tests.Client.Base;

internal class SignUp
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
    public void Anonymsously_Success()
    {
        // Mock request/response
        SignUpRequest request = new();
        SignUpResponse response = default!;

        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            response = await client.SignUpAsync(request);
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
            response = await client.SignUpAsync(request);
        });

        // Write result
        TestData.Write(response);
    }
}