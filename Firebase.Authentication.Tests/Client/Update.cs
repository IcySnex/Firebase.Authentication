using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Configuration;

namespace Firebase.Authentication.Tests.Client;

public class Update
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        // Mock config/base
        HttpConfig httpConfig = new(TestData.Timeout, TestData.Proxy);
        AuthenticationConfig config = new(TestData.ApiKey, httpConfig);

        client = new AuthenticaionClient(config);

        // Sign in
        SignInRequest signInRequest = SignInRequest.WithEmailPassword(TestData.Email, TestData.Password);
        await client.SignInAsync(signInRequest);
    }


    [Test]
    public void DisplayNameAndPhotoUrl_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.UpdateAsync(TestData.DisplayName, TestData.PhotoUrl, default);

            Assert.That(client.CurrentUser!.DisplayName, Is.EqualTo(TestData.DisplayName));
            Assert.That(client.CurrentUser!.PhotoUrl, Is.EqualTo(TestData.PhotoUrl));
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void RemoveDisplayNameAndPhotoUrl_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.UpdateAsync(null, null, true, true, default);

            Assert.That(client.CurrentUser!.DisplayName, Is.Null);
            Assert.That(client.CurrentUser!.PhotoUrl, Is.Null);
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }
}