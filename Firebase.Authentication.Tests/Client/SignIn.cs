using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;

namespace Firebase.Authentication.Tests.Client;

public class SignIn
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
    public void WithEmailPassword_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            SignInRequest signInRequest = SignInRequest.WithEmailPassword(TestData.Email, TestData.Password);
            await client.SignInAsync(signInRequest);

            Assert.That(client.CurrentCredential, Is.Not.Null);
            Assert.That(client.CurrentUser, Is.Not.Null);
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void WithCustomToken_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            SignInRequest signInRequest = SignInRequest.WithCustomToken(TestData.CustomToken);
            await client.SignInAsync(signInRequest);

            Assert.That(client.CurrentCredential, Is.Not.Null);
            Assert.That(client.CurrentUser, Is.Not.Null);
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void WithPhoneNumber_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            SignInRequest signInRequest = SignInRequest.WithPhoneNumber(TestData.SessionInfo, TestData.SmsCode);
            await client.SignInAsync(signInRequest);

            Assert.That(client.CurrentCredential, Is.Not.Null);
            Assert.That(client.CurrentUser, Is.Not.Null);
        });

        // Write result
        TestData.Write(client.CurrentCredential);
        TestData.Write(client.CurrentUser);
    }
}