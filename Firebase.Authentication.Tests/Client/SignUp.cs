using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;

namespace Firebase.Authentication.Tests.Client;

public class SignUp
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
    public void WithEmailPassword_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            SignUpRequest signUpRequest = SignUpRequest.WithEmailPassword(TestData.Email, TestData.Password, TestData.DisplayName, TestData.PhotoUrl);
            await client.SignUpAsync(signUpRequest);

            Assert.That(client.CurrentCredential, Is.Not.Null);
            Assert.That(client.CurrentUser, Is.Not.Null);
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void Anonymously_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            SignUpRequest signUpRequest = SignUpRequest.Anonymously(TestData.DisplayName, TestData.PhotoUrl);
            await client.SignUpAsync(signUpRequest);

            Assert.That(client.CurrentCredential, Is.Not.Null);
            Assert.That(client.CurrentUser, Is.Not.Null);
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }
}