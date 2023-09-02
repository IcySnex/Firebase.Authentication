using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Configuration;

namespace Firebase.Authentication.Tests.Client;

public class Email
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        client = new AuthenticationClient(config);

        // Sign in
        SignInRequest signInRequest = SignInRequest.WithEmailPassword(TestData.Email, TestData.Password);
        await client.SignInAsync(signInRequest);
    }


    [Test]
    public void Change_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.ChangeEmailAsync(TestData.EmailSecondary);

            Assert.That(client.CurrentUser!.Email, Is.EqualTo(TestData.EmailSecondary));
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void Remove_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.ChangeEmailAsync(null);

            Assert.That(client.CurrentUser!.Email, Is.EqualTo(null));
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }
}