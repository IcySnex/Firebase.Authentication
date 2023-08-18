using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Models;

namespace Firebase.Authentication.Tests.Client;

internal class RefreshCredential
{
    IAuthenticationClient client;

    [OneTimeSetUp]
    public async Task SetupAsymc()
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
    [Ignore("Takes too long: The default expiration time is 1 hour!")]
    public void Refresh_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            // Get new authentication
            Credential oldCredential = client.CurrentCredential!;
            await Task.Delay(oldCredential.ExpiresIn);
            Credential newCredential = await client.GetFreshCredentialAsync();

            // Run Test: Expected behaviour: new refresh token dont not equal old refresh token
            Assert.That(newCredential.RefreshToken, Is.Not.EqualTo(oldCredential.RefreshToken));

            // Write result
            TestData.Write(newCredential);
        });
    }

    [Test]
    public void DontRefresh_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            // Get new authentication
            Credential oldCredential = client.CurrentCredential!;
            Credential newCredential = await client.GetFreshCredentialAsync();

            // Run Test: Expected behaviour: new refresh token equals old refresh token
            Assert.That(newCredential.RefreshToken, Is.EqualTo(oldCredential.RefreshToken));

            // Write result
            TestData.Write(newCredential);
        });
    }
}