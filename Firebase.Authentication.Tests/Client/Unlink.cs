using Firebase.Authentication.Client.Interfaces;
using Firebase.Authentication.Client;
using Firebase.Authentication.Configuration;
using Firebase.Authentication.Requests;
using Firebase.Authentication.Types;

namespace Firebase.Authentication.Tests.Client;

public class Unlink
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
    public void FromEmailPassword_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.UnlinkAsync(Provider.EmailAndPassword, default);

            Assert.That(client.CurrentUser!.ProviderUserInfos?.Any(info => info.Provider != Provider.EmailAndPassword) ?? true);
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void FromPhoneNumber_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.UnlinkAsync(Provider.PhoneNumber, default);

            Assert.That(client.CurrentUser!.ProviderUserInfos?.Any(info => info.Provider != Provider.PhoneNumber) ?? true);
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void FromEmailLink_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.UnlinkAsync(Provider.EmailLink, default);

            Assert.That(client.CurrentUser!.ProviderUserInfos?.Any(info => info.Provider != Provider.EmailLink) ?? true);
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }

    [Test]
    public void FromProvider_Success()
    {
        // Run Test: Expected behaviour: Run without exception
        Assert.DoesNotThrowAsync(async () =>
        {
            await client.UnlinkAsync(TestData.Provider, default);

            Assert.That(client.CurrentUser!.ProviderUserInfos?.Any(info => info.Provider != TestData.Provider) ?? true);
        });

        // Write result
        TestData.Write(client.CurrentUser);
    }
}